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
    public class ProductInWarehousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductInWarehousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductInWarehouses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductInWarehouse.ToListAsync());
        }

        // GET: ProductInWarehouses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _context.ProductInWarehouse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }

            return View(productInWarehouse);
        }

        // GET: ProductInWarehouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductInWarehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,WarehouseId,Quantity,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] ProductInWarehouse productInWarehouse)
        {
            if (ModelState.IsValid)
            {
                productInWarehouse.Id = Guid.NewGuid();
                _context.Add(productInWarehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productInWarehouse);
        }

        // GET: ProductInWarehouses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _context.ProductInWarehouse.FindAsync(id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }
            return View(productInWarehouse);
        }

        // POST: ProductInWarehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductId,WarehouseId,Quantity,Id,CreatedBy,CreatedAt,DeletedBy,DeletedAt")] ProductInWarehouse productInWarehouse)
        {
            if (id != productInWarehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productInWarehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInWarehouseExists(productInWarehouse.Id))
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
            return View(productInWarehouse);
        }

        // GET: ProductInWarehouses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _context.ProductInWarehouse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }

            return View(productInWarehouse);
        }

        // POST: ProductInWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productInWarehouse = await _context.ProductInWarehouse.FindAsync(id);
            _context.ProductInWarehouse.Remove(productInWarehouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInWarehouseExists(Guid id)
        {
            return _context.ProductInWarehouse.Any(e => e.Id == id);
        }
    }
}
