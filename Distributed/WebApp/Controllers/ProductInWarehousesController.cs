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
            var applicationDbContext = _context.ProductInWarehouses.Include(p => p.Product).Include(p => p.Warehouse);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductInWarehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _context.ProductInWarehouses
                .Include(p => p.Product)
                .Include(p => p.Warehouse)
                .FirstOrDefaultAsync(m => m.ProductInWarehouseId == id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }

            return View(productInWarehouse);
        }

        // GET: ProductInWarehouses/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseCode");
            return View();
        }

        // POST: ProductInWarehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductInWarehouseId,ProductId,WarehouseId,Quantity")] ProductInWarehouse productInWarehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productInWarehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", productInWarehouse.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseCode", productInWarehouse.WarehouseId);
            return View(productInWarehouse);
        }

        // GET: ProductInWarehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _context.ProductInWarehouses.FindAsync(id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", productInWarehouse.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseCode", productInWarehouse.WarehouseId);
            return View(productInWarehouse);
        }

        // POST: ProductInWarehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductInWarehouseId,ProductId,WarehouseId,Quantity")] ProductInWarehouse productInWarehouse)
        {
            if (id != productInWarehouse.ProductInWarehouseId)
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
                    if (!ProductInWarehouseExists(productInWarehouse.ProductInWarehouseId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductCode", productInWarehouse.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseCode", productInWarehouse.WarehouseId);
            return View(productInWarehouse);
        }

        // GET: ProductInWarehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _context.ProductInWarehouses
                .Include(p => p.Product)
                .Include(p => p.Warehouse)
                .FirstOrDefaultAsync(m => m.ProductInWarehouseId == id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }

            return View(productInWarehouse);
        }

        // POST: ProductInWarehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productInWarehouse = await _context.ProductInWarehouses.FindAsync(id);
            _context.ProductInWarehouses.Remove(productInWarehouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInWarehouseExists(int id)
        {
            return _context.ProductInWarehouses.Any(e => e.ProductInWarehouseId == id);
        }
    }
}
