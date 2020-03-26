using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebApp.Controllers
{
    public class PricesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Price.ToListAsync());
        }

        // GET: Prices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Price
                .FirstOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // GET: Prices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,CampaignId,ProductPrice,StartTime,EndTime,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] Price price)
        {
            if (ModelState.IsValid)
            {
                price.Id = Guid.NewGuid();
                _context.Add(price);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(price);
        }

        // GET: Prices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Price.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId,CampaignId,ProductPrice,StartTime,EndTime,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] Price price)
        {
            if (id != price.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(price);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceExists(price.Id))
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
            return View(price);
        }

        // GET: Prices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var price = await _context.Price
                .FirstOrDefaultAsync(m => m.Id == id);
            if (price == null)
            {
                return NotFound();
            }

            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var price = await _context.Price.FindAsync(id);
            _context.Price.Remove(price);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceExists(Guid id)
        {
            return _context.Price.Any(e => e.Id == id);
        }
    }
}
