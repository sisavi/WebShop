#pragma warning disable 1591
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain.App;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;
using Basket = BLL.App.DTO.Basket;
using DeliveryType = BLL.App.DTO.DeliveryType;
using ProductInBasket = BLL.App.DTO.ProductInBasket;

namespace WebApp.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IAppBLL _bll;

        public OrdersController(IAppBLL bll)
        {
            _bll = bll;
        }
        
        // GET: Orders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _bll.Orders.FirstOrDefaultAsync(id.Value);

            var scId = _bll.Baskets.GetByAppUserId(User.UserId()).Id;
            
            var vm = new BasketViewModel
            {
                Basket = await _bll.Baskets.FirstOrDefaultAsync(scId),
                Order = await _bll.Orders.FirstOrDefaultAsync(id.Value),
                Products = await _bll.ProductInBasket.GetProductsForBasketAsync(scId),
                SubTotal = await _bll.ProductInBasket.GetTotalCost(scId),
                DeliveryTypeSelectList = new SelectList(
                    _bll.DeliveryTypes.GetAllAsync().Result, 
                    nameof(DeliveryType.Id), nameof(DeliveryType.DeliveryTypeName)),
            };

            if (order == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        public async Task<IActionResult> MakeOrder(BasketViewModel vm, string orderId)
        {
            await _bll.Orders.PlaceOrder(vm.Basket!.Id, User.UserId(), vm.Order!.Address, vm.Order.PhoneNumber, vm.Order.DeliveryTypeId);
            await _bll.Orders.CopyBasket(_bll.Baskets.GetByAppUserId(User.UserId()).Id, Guid.Parse(orderId));
            await _bll.Baskets.ClearBasket(_bll.Baskets.GetByAppUserId(User.UserId()).Id);
            await _bll.SaveChangesAsync();

            return RedirectToAction("Index", "Products");
        }

    }

    
}
