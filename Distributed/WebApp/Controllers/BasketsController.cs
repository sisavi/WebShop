using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class BasketsController : Controller
    {
        private readonly IAppBLL _bll;
        public BasketsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Baskets
        public async Task<IActionResult> Index()
        {
            var sc = _bll.Baskets.GetByAppUserId(User.UserId());

            var vm = new BasketViewModel
            {
                Basket = await _bll.Baskets.FirstOrDefaultAsync(sc.Id),
                Products = await _bll.ProductInBasket.GetProductsForBasketAsync(sc.Id),
                SubTotal = await _bll.ProductInBasket.GetTotalCost(sc.Id)
            };

            return View(vm);
        }
        

        // GET: Baskets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Basket = await _bll.Baskets.FirstOrDefaultAsync(id.Value);
            if (Basket == null)
            {
                return NotFound();
            }

            return View(Basket);
        }

        // GET: Baskets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BLL.App.DTO.Basket Basket)
        {
            if (ModelState.IsValid)
            {
                _bll.Baskets.Add(Basket);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Basket);
        }

        // GET: Baskets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Basket = await _bll.Baskets.FirstOrDefaultAsync(id.Value);
            if (Basket == null)
            {
                return NotFound();
            }
            return View(Basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BLL.App.DTO.Basket Basket)
        {
            if (id != Basket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                await _bll.Baskets.UpdateAsync(Basket);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Basket);
        }

        // GET: Baskets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Basket = await _bll.Baskets.FirstOrDefaultAsync(id.Value);
            if (Basket == null)
            {
                return NotFound();
            }

            return View(Basket);
        }

        // POST: Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Basket = await _bll.Baskets.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
