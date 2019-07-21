using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogRegIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LogRegIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppIdentityUserDbContext _dbContext;

        public HomeController(AppIdentityUserDbContext dbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
