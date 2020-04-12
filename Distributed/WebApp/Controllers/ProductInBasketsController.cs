using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProductInBasketsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ProductInBasketsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ProductInBaskets
        public async Task<IActionResult> Index()
        {
            return View(await _uow.ProductsInBaskets.AllAsync());
        }

        // GET: ProductInBaskets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _uow.ProductsInBaskets.FindAsync(id);
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
        public async Task<IActionResult> Create([Bind("BasketId,ProductId,Quantity,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] ProductInBasket productInBasket)
        {
            if (ModelState.IsValid)
            {
                productInBasket.Id = Guid.NewGuid();
                _uow.ProductsInBaskets.Add(productInBasket);
                await _uow.SaveChangesAsync();
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

            var productInBasket = await _uow.ProductsInBaskets.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("BasketId,ProductId,Quantity,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] ProductInBasket productInBasket)
        {
            if (id != productInBasket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ProductsInBaskets.Update(productInBasket);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInBasketExists(productInBasket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            var productInBasket = await _uow.ProductsInBaskets.FindAsync(id);
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
            var productInBasket = await _uow.ProductsInBaskets.FindAsync(id);
            _uow.ProductsInBaskets.Remove(productInBasket);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInBasketExists(Guid id)
        {
            var contains = _uow.ProductsInBaskets.Find(id);
            return contains != null;
        }
    }
}
