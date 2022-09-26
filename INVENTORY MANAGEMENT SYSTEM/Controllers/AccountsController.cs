using Core.Models;
using Core.ViewModels;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace INVENTORY_MANAGEMENT_SYSTEM.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountHelper _accountHelper;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountHelper accountHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountHelper = accountHelper;
        }

        //CREATE ADMIN ACCOUNT GET 
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        //CREATE ADMIN ACCOUNT POST 
        [HttpPost]
        public async Task<JsonResult> CreateAdminAccount(string applicationUserViewModel)
        {
            try
            {
                var newAdmin = JsonConvert.DeserializeObject<ApplicationUserViewModel>(applicationUserViewModel);

                //We did all the validations
                if (newAdmin.FirstName == null)
                {
                    return Json(new { isError = true, msg = "Please enter your first" });
                }
                if (newAdmin.LastName == null)
                {
                    return Json(new { isError = true, msg = "Please enter your  last name" });
                }
                if (newAdmin.Email == null)
                {
                    return Json(new { isError = true, msg = "Please enter your email" });
                }
                if (newAdmin.UserName == null)
                {
                    return Json(new { isError = true, msg = "Please enter your UserName" });
                }
                if (newAdmin.Password == null)
                {
                    return Json(new { isError = true, msg = "Please enter your Password" });
                }
                if (newAdmin.ConfirmPassword == null)
                {
                    return Json(new { isError = true, msg = "Please enter password confirmation" });
                }
                if (newAdmin.Password != newAdmin.ConfirmPassword)
                {
                    return Json(new { isError = true, msg = "Please your password and confirm paasword not matched" });
                }
                // End Validations

                // Query the user details if it exists in the Db B4 Authentication
                var accountCheck = await _userManager.FindByEmailAsync(newAdmin.Email);
                if (accountCheck != null)
                {
                    return Json(new { isError = true, msg = "Email already exist" });
                }
                var result = _accountHelper.CreateNewAdmin(newAdmin).Result;

                if (result != null)
                {
                    var addToRole = _userManager.AddToRoleAsync(result, "Admin").Result;
                    if (addToRole.Succeeded)
                    {
                        return Json(new { isError = false, msg = "Admin Created Successfully" });

                    }
                    return Json(new { isError = true, msg = "Failed" });

                }
                return Json(new { isError = true, msg = "Failed" });
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public IActionResult LogOut()
        {
            _accountHelper.LogOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
