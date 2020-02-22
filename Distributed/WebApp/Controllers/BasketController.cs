using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Basket
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Baskets.Include(b => b.Account);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Basket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets
                .Include(b => b.Account)
                .FirstOrDefaultAsync(m => m.BasketId == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Basket/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Email");
            return View();
        }

        // POST: Basket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasketId,AccountId")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Email", basket.AccountId);
            return View(basket);
        }

        // GET: Basket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Email", basket.AccountId);
            return View(basket);
        }

        // POST: Basket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BasketId,AccountId")] Basket basket)
        {
            if (id != basket.BasketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketExists(basket.BasketId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Email", basket.AccountId);
            return View(basket);
        }

        // GET: Basket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets
                .Include(b => b.Account)
                .FirstOrDefaultAsync(m => m.BasketId == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Basket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basket = await _context.Baskets.FindAsync(id);
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketExists(int id)
        {
            return _context.Baskets.Any(e => e.BasketId == id);
        }
    }
}
