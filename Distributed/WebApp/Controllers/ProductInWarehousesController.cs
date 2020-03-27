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
    public class ProductInWarehousesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ProductInWarehousesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ProductInWarehouses
        public async Task<IActionResult> Index()
        {
            return View(await _uow.ProductsInWarehouse.AllAsync());
        }

        // GET: ProductInWarehouses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _uow.ProductsInWarehouse.FindAsync(id);
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
        public async Task<IActionResult> Create(ProductInWarehouse productInWarehouse)
        {
            if (ModelState.IsValid)
            {
                productInWarehouse.Id = Guid.NewGuid();
                _uow.ProductsInWarehouse.Add(productInWarehouse);
                await _uow.SaveChangesAsync();
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

            var productInWarehouse = await _uow.ProductsInWarehouse.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, ProductInWarehouse productInWarehouse)
        {
            if (id != productInWarehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ProductsInWarehouse.Update(productInWarehouse);
                    await _uow.SaveChangesAsync();
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

            var productInWarehouse = await _uow.ProductsInWarehouse.FindAsync(id);
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
            var productInWarehouse = await _uow.ProductsInWarehouse.FindAsync(id);
            _uow.ProductsInWarehouse.Remove(productInWarehouse);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductInWarehouseExists(Guid id)
        {
            var contains = _uow.ProductsInWarehouse.Find(id);
            return contains != null;
        }
    }
}
