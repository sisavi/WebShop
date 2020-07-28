using System;
using System.IO;
using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Areas.Admin.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PicturesController : Controller
    {
        private readonly IAppBLL _bll;
        public IWebHostEnvironment _env;
        


        public PicturesController(IAppBLL bll, IWebHostEnvironment env)
        {
            _bll = bll;
            _env = env;
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Pictures.GetAllAsync());
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _bll.Pictures.FirstOrDefaultAsync(id.Value);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Pictures/Create
        public IActionResult Create()
        {
            var vm = new PictureCreateEditViewModel()
            {
                ProductSelectList =
                    new SelectList(_bll.Products.GetAllAsync().Result, nameof(Product.Id), nameof(Product.ProductName))
            };
            return View(vm);
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PictureCreateEditViewModel vm)
        {
            //var root = "/Distributed/WebApp/wwwroot/";
            var fileInfo = new FileInfo(vm.Picture.ImageFail.Name);
            
            if (ModelState.IsValid)
            {
                using (var fileStream = new FileStream(Path.Combine(_env.ContentRootPath, "wwwroot/image/" + vm.Picture.Name + ".png"), FileMode.OpenOrCreate))
                {
                    
                    await vm.Picture.ImageFail.CopyToAsync(fileStream);
                    Console.WriteLine(fileStream.ToString());
                }
                
                

                vm.Picture.PictureName = @"\wwwroot\image\" + vm.Picture.Name + ".png";
                    _bll.Pictures.Add(vm.Picture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            vm.ProductSelectList = new SelectList(
                _bll.Products.GetAllAsync().Result, nameof(Product.Id), nameof(Product.ProductName), vm.Picture!.ProductId);
            return View(vm);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _bll.Pictures.FirstOrDefaultAsync(id.Value);
            if (picture == null)
            {
                return NotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BLL.App.DTO.Picture picture)
        {
            if (id != picture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    await _bll.Pictures.UpdateAsync(picture);
                    await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _bll.Pictures.FirstOrDefaultAsync(id.Value);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var picture = await _bll.Pictures.RemoveAsync(id);
            
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
