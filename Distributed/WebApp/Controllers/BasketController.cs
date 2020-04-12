using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
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
            return View(await _uow.Baskets.AllAsync(User.UserGuidId()));
        }

        // GET: Basket/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _uow.Baskets.FirstOrDefaultAsync(id.Value, User.UserGuidId());
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Basket/Create
        public IActionResult Create()
        {
            var vm = new BasketEditCreateViewModel();
            vm.AccountSelectList = new SelectList(_uow.Accounts.All(), nameof(Account.Id), nameof(Account.FirstName));
            return View(vm);
        }

        // POST: Basket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BasketEditCreateViewModel basket)
        {
            basket.Basket.CreatedAt = DateTime.Now;
            basket.Basket.DeletedAt = DateTime.MaxValue;
            basket.AccountSelectList = new SelectList(_uow.Accounts.All(), nameof(Account.Id), nameof(Account.FirstName));
            if (ModelState.IsValid)
            {
                _uow.Baskets.Add(basket.Basket);
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
            var basket = new BasketEditCreateViewModel();
            basket.AccountSelectList = new SelectList(_uow.Accounts.All(), nameof(Account.Id), nameof(Account.FirstName));

            basket.Basket = await _uow.Baskets.FirstOrDefaultAsync(id.Value, User.UserGuidId());
            if (basket.Basket == null)
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
        public async Task<IActionResult> Edit(Guid id, BasketEditCreateViewModel vm)
        {
            if (id != vm.Basket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Baskets.Update(vm.Basket);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _uow.Baskets.ExistsAsync(vm.Basket.Id, User.UserGuidId()))
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

            return View(vm);
        }

        // GET: Basket/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _uow.Baskets.FirstOrDefaultAsync(id.Value, User.UserGuidId());
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
            await _uow.Baskets.DeleteAsync(id, User.UserGuidId());
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));;
        }

        private bool BasketExists(Guid id)
        {

            var contains = _uow.Baskets.Find(id);
            return contains != null;
        }
    }
}
