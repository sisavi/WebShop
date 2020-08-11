using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using ee.itcollege.sisavi.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using Order = BLL.App.DTO.Order;

namespace BLL.App.Services
{
    public class OrderService : BaseEntityService<IAppUnitOfWork, IOrderRepository, IOrderServiceMapper,
        DAL.App.DTO.Order, BLL.App.DTO.Order>, IOrderService

    {
        public OrderService(IAppUnitOfWork uow) : base(uow, uow.Orders, new OrderServiceMapper())
        {
        }
        
        public async Task<Guid?> PlaceOrder(Guid id, Guid userId, string address, string phone, Guid deliveryTypeId)
        {
            if (UOW.Baskets.GetByAppUserId(userId).Id.Equals(id))
            {
                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    BasketId = id,
                    AppUserId = userId,
                    DateTime = DateTime.Now,
                    Address = address,
                    PhoneNumber = phone,
                    DeliveryTypeId = deliveryTypeId,
                    TotalCost = Math.Round(UOW.ProductInBasket.GetProductsForBasketAsync(UOW.Baskets.GetByAppUserId(userId).Id).Result.Sum(a => a.TotalCost), 2, MidpointRounding.ToEven)
                };
 
                UOW.Orders.Add(Mapper.Map(order));
                await UOW.SaveChangesAsync();
 
                return order.Id;
            }
 
            return null;
        }

        public async Task<Guid> PlaceOrderForApi(PublicApi.DTO.v2.Order orderCreate)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                BasketId = orderCreate.BasketId,
                AppUserId = orderCreate.AppUserId,
                DateTime = DateTime.Now,
                TotalCost = Math.Round((orderCreate.TotalCost), 2),
                Address = orderCreate.Address,
                PhoneNumber = orderCreate.PhoneNumber,
                DeliveryTypeId = orderCreate.DeliveryTypeId
            };
            
            UOW.Orders.Add(Mapper.Map(order));
            await UOW.SaveChangesAsync();

            return order.Id;
        }
 
        public async Task CopyBasket(Guid basketId, Guid orderId)
        {
            foreach (var productInList in UOW.ProductInBasket.GetProductsForBasketAsync(basketId).Result)
            {
                UOW.ProductInBasket.Add(new ProductInBasket()
                {
                    Id = Guid.NewGuid(),
                    BasketId = basketId,
                    ProductId = productInList.ProductId,
                    OrderId = orderId,
                    Quantity = productInList.Quantity,
                    TotalCost = productInList.TotalCost
                });

                await UOW.ProductInBasket.RemoveAsync(productInList);
            }
 
            await UOW.SaveChangesAsync();
            
            
        }
        
    }
}