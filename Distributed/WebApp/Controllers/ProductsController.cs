#pragma warning disable 1591
using System;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAppBLL _bll;

        public ProductsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Products
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var vm = new ProductIndexViewModel()
            {
                Products = await _bll.Products.GetAllAsync(),
                Categories = await _bll.Categories.GetAllAsync(),
                Campaigns = await _bll.Campaigns.GetAllAsync()
                
            };
            

            return View(vm);
        }

        [AllowAnonymous]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var product = await _bll.Products.FirstOrDefaultAsync(id.Value);
            //var category = await _bll.Categories.FirstOrDefaultAsync(product.CategoryId);
            var vm = new ProductDetailsDeleteViewModel()
            {
                Product = product,
                Categories = await _bll.Categories.GetAllAsync(),
                CategoryName = _bll.Categories.FirstOrDefaultAsync(product.CategoryId).Result.CategoryName,
                

            };
            

            
            if (vm.Product == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [Authorize(Roles = "admin")]
        // GET: Products/Create
        public IActionResult Create()
        {
            var vm = new ProductCreateEditViewModel()
            {
                CategoryNameSelectList =
                    new SelectList(_bll.Categories.GetAllAsync().Result, nameof(Category.Id), nameof(Category.CategoryName)),
                CampaignNameSelectList = new SelectList(_bll.Campaigns.GetAllAsync().Result, nameof(Campaign.Id), nameof(Campaign.Discount))
                
                
            };
            
            return View(vm);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                
                
                _bll.Products.Add(new Product()
                {
                    ProductPrice = vm.ProductPrice,
                    CategoryId = vm.Product.CategoryId,
                    Description = vm.Product.Description,
                    ProductCode = vm.Product.ProductCode,
                    ProductName = vm.Product.ProductName,
                    CampaignId  = vm.CampaignId,
                    
                    

                });
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.CategoryNameSelectList = new SelectList(
                _bll.Categories.GetAllAsync().Result, nameof(Category.Id), nameof(Category.CategoryName), vm.Product!.CategoryId);
            vm.CampaignNameSelectList = new SelectList(_bll.Campaigns.GetAllAsync().Result, nameof(Campaign.Id),
                nameof(Campaign.Discount));
            
            return View(vm);
        }

        
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vm = new ProductCreateEditViewModel()
            {
                Product = await _bll.Products.FirstOrDefaultAsync(id.Value),
                CategoryNameSelectList =
                    new SelectList(_bll.Categories.GetAllAsync().Result, nameof(Category.Id), nameof(Category.CategoryName)),
                CampaignNameSelectList = new SelectList(_bll.Campaigns.GetAllAsync().Result, nameof(Campaign.Id), nameof(Campaign.Discount))
            };

            
            if (vm.Product == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductCreateEditViewModel vm)
        {
            vm.Product.Id = id;
            if (id != vm.Product.Id)
            {
                return NotFound($"{id.ToString()} and {vm.Product.Id.ToString()} are not equal");
            }

            if (ModelState.IsValid)
            {
               
                await _bll.Products.UpdateAsync(vm.Product);
                await _bll.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _bll.Products.FirstOrDefaultAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _bll.Products.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
