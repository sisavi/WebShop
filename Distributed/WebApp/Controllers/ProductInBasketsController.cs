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
    public class ProductInBasketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductInBasketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductInBaskets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductInBaskets.Include(p => p.Basket).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductInBaskets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _context.ProductInBaskets
                .Include(p => p.Basket)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductInBasketId == id);
            if (productInBasket == null)
            {
                return NotFound();
            }

            return View(productInBasket);
        }

        // GET: ProductInBaskets/Create
        public IActionResult Create()
        {
            ViewData["BasketId"] = new SelectList(_context.Baskets, "BasketId", "BasketId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode");
            return View();
        }

        // POST: ProductInBaskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductInBasketId,BasketId,ProductId,Quantity")] ProductInBasket productInBasket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInBasket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BasketId"] = new SelectList(_context.Baskets, "BasketId", "BasketId", productInBasket.BasketId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", productInBasket.ProductId);
            return View(productInBasket);
        }

        // GET: ProductInBaskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _context.ProductInBaskets.FindAsync(id);
            if (productInBasket == null)
            {
                return NotFound();
            }
            ViewData["BasketId"] = new SelectList(_context.Baskets, "BasketId", "BasketId", productInBasket.BasketId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", productInBasket.ProductId);
            return View(productInBasket);
        }

        // POST: ProductInBaskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductInBasketId,BasketId,ProductId,Quantity")] ProductInBasket productInBasket)
        {
            if (id != productInBasket.ProductInBasketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInBasket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInBasketExists(productInBasket.ProductInBasketId))
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
            ViewData["BasketId"] = new SelectList(_context.Baskets, "BasketId", "BasketId", productInBasket.BasketId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", productInBasket.ProductId);
            return View(productInBasket);
        }

        // GET: ProductInBaskets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInBasket = await _context.ProductInBaskets
                .Include(p => p.Basket)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductInBasketId == id);
            if (productInBasket == null)
            {
                return NotFound();
            }

            return View(productInBasket);
        }

        // POST: ProductInBaskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productInBasket = await _context.ProductInBaskets.FindAsync(id);
            _context.ProductInBaskets.Remove(productInBasket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInBasketExists(int id)
        {
            return _context.ProductInBaskets.Any(e => e.ProductInBasketId == id);
        }
    }
}
