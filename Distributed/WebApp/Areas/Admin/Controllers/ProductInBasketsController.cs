using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductInBasketsController : Controller
    {
        private readonly IAppBLL _bll;
        public ProductInBasketsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ProductInBaskets
        public async Task<IActionResult> Index()
        {
            return View(await _bll.ProductsInBaskets.GetAllAsync());
        }

        // GET: ProductInBaskets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _bll.ProductsInBaskets.FirstOrDefaultAsync(id.Value);
            if (productInBasket == null)
            {
                return NotFound();
            }

            return View(productInBasket);
        }

        // GET: ProductInBaskets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductInBaskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BLL.App.DTO.ProductInBasket productInBasket)
        {
            if (ModelState.IsValid)
            {
                _bll.ProductsInBaskets.Add(productInBasket);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productInBasket);
        }

        // GET: ProductInBaskets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _bll.ProductsInBaskets.FirstOrDefaultAsync(id.Value);
            if (productInBasket == null)
            {
                return NotFound();
            }
            return View(productInBasket);
        }

        // POST: ProductInBaskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BLL.App.DTO.ProductInBasket productInBasket)
        {
            if (id != productInBasket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                await _bll.ProductsInBaskets.UpdateAsync(productInBasket);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productInBasket);
        }

        // GET: ProductInBaskets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _bll.ProductsInBaskets.FirstOrDefaultAsync(id.Value);
            if (productInBasket == null)
            {
                return NotFound();
            }

            return View(productInBasket);
        }

        // POST: ProductInBaskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productInBasket = await _bll.ProductsInBaskets.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
