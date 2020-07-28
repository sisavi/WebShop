using System;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductInWarehousesController : Controller
    {
        private readonly IAppBLL _bll;
        public ProductInWarehousesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ProductInWarehouses
        public async Task<IActionResult> Index()
        {
            return View(await _bll.ProductsInWarehouse.GetAllAsync());
        }

        // GET: ProductInWarehouses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productInWarehouse = await _bll.ProductsInWarehouse.FirstOrDefaultAsync(id.Value);
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
        public async Task<IActionResult> Create(BLL.App.DTO.ProductInWarehouse productInWarehouse)
        {
            if (ModelState.IsValid)
            {
                _bll.ProductsInWarehouse.Add(productInWarehouse);
                await _bll.SaveChangesAsync();
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

            var productInWarehouse = await _bll.ProductsInWarehouse.FirstOrDefaultAsync(id.Value);
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
        public async Task<IActionResult> Edit(Guid id, BLL.App.DTO.ProductInWarehouse productInWarehouse)
        {
            if (id != productInWarehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bll.ProductsInWarehouse.UpdateAsync(productInWarehouse);
                await _bll.SaveChangesAsync();
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

            var productInWarehouse = await _bll.ProductsInWarehouse.FirstOrDefaultAsync(id.Value);
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
            var productInWarehouse = await _bll.ProductsInWarehouse.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
