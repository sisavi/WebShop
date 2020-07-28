using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RoleManager<IdentityRole> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, RoleManager<IdentityRole> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET
        public IActionResult Index()
        {
            return null;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

    }
}