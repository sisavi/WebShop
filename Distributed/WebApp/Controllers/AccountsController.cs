using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Identity;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        
        private readonly IAppUnitOfWork _uow;
        

        public AccountsController(IAppUnitOfWork uow)
        {
            _uow = uow;
            
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _uow.Accounts.AllAsync(User.UserGuidId());
            return View(appDbContext);
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _uow.Accounts.FirstOrDefaultAsync(id.Value, User.UserGuidId());
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            //var vm = new AccountEditCreateViewModels();
            //vm.AppUsersSelectList = new SelectList(_uow.Accounts.All(), nameof(Account.Id), nameof(Account.FirstName));
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AccountEditCreateViewModels vm)
        {
            
            vm.Account.AppUserId = User.UserGuidId();
            vm.Account.CreatedAt = DateTime.Now;
            vm.Account.DeletedAt = DateTime.MaxValue;
            if (ModelState.IsValid)
            {
                //vm.Account.Id = Guid.NewGuid();
                _uow.Accounts.Add(vm.Account);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = new AccountEditCreateViewModels();
            account.Account =
                await _uow.Accounts.FirstOrDefaultAsync(id.Value, User.UserGuidId());
            if (account == null)
            {
                return NotFound();
            }
            //ViewData["AppUserId"] = new SelectList(_uow.Accounts.All(), nameof(account.AppUserId), nameof(AppUser.FirstName), account.AppUserId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AccountEditCreateViewModels account)
        {
            account.Account.AppUserId = User.UserGuidId();
            if (id != account.Account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Accounts.Update(account.Account);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _uow.Accounts.ExistsAsync(account.Account.Id, User.UserGuidId()))
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
            //ViewData["AppUserId"] = new SelectList(_uow.Accounts.All(), nameof(account.AppUserId), nameof(AppUser.FirstName), account.AppUserId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _uow.Accounts.FirstOrDefaultAsync(id.Value, User.UserGuidId()) ;
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Accounts.DeleteAsync(id, User.UserGuidId());
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
/*
        private bool AccountExists(Guid id)
        {
            return _uow.Accounts.Equals(_uow.Accounts.All().Where(a => a.Id == id));
            }
*/
    }
}
