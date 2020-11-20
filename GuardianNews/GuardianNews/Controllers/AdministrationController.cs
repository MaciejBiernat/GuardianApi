using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GuardianNews.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GuardianNews.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController( RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        public async Task<IActionResult> AddAdminRole()
        {
            // first creates Admin role if none in db
            if(!await _roleManager.RoleExistsAsync("Admin")){
                IdentityRole identityRole = new IdentityRole
                {
                    Name = "Admin"
                };
                await _roleManager.CreateAsync(identityRole);
            }

            // Add user to Admin role
            var user = await _userManager.GetUserAsync(User);

            var result = await _userManager.AddToRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                return RedirectToAction("LogoutRedirect", "account");
            }

            return RedirectToAction("index", "home");
        }
    }
}
