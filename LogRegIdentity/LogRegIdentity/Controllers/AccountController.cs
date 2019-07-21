using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogRegIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LogRegIdentity.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppIdentityUserDbContext _dbContext;

        public AccountController(AppIdentityUserDbContext dbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.Name,
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync
                    (model.Name, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", "Home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }

            return View(model);
        }
        
    }
}