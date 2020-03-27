using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public BasketController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Basket
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Baskets.AllAsync());
        }

        // GET: Basket/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _uow.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Basket/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Basket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Basket basket)
        {
            if (ModelState.IsValid)
            {
                basket.Id = Guid.NewGuid();
                _uow.Baskets.Add(basket);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(basket);
        }

        // GET: Basket/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _uow.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Basket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AccountId,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")]
            Basket basket)
        {
            if (id != basket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Baskets.Update(basket);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketExists(basket.Id))
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

            return View(basket);
        }

        // GET: Basket/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _uow.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Basket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var basket = await _uow.Baskets.FindAsync(id);
            _uow.Baskets.Remove(basket);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketExists(Guid id)
        {

            var contains = _uow.Baskets.Find(id);
            return contains != null;
        }
    }
}
