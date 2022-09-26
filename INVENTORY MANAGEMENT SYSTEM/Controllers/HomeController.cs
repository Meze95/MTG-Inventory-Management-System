using Core.Data;
using Core.Models;
using Core.ViewModels;
using INVENTORY_MANAGEMENT_SYSTEM.Models;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace INVENTORY_MANAGEMENT_SYSTEM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IAccountHelper _accountHelper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountHelper accountHelper)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _accountHelper = accountHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Login POST ACTION
        [HttpPost]
        public async Task<JsonResult> Login(string loginViewModel)
        { 
            if(loginViewModel == null)
            {
                return Json(new { isError = true, msg = "Fill the form" });
            }

            var userDetails = JsonConvert.DeserializeObject<LoginViewModel>(loginViewModel);
            if (userDetails.Email == "")
            {
                return Json(new { isError = true, msg = "Enter your email" });
            }
            if (userDetails.Password == "")
            {
                return Json(new { isError = true, msg = "Enter your password" });
            }
            var user = _db.ApplicationUser.Where(x => x.Email == userDetails.Email).FirstOrDefault();
            if (user != null)
            {
                var currentUser = await _signInManager.PasswordSignInAsync(user.UserName, userDetails.Password, true, true);
                if (currentUser.Succeeded)
                {
                    var dashboard = _accountHelper.GetUserIndex(user);
                    return Json(new { isError = false, msg = "Welcome!", dashboard = dashboard });
                }
            }
            return Json(new { isError = true, msg = "Login Failed" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}