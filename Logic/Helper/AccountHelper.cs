using Core.Models;
using Core.ViewModels;
using Logic.IHelper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helper
{
    public class AccountHelper: IAccountHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountHelper(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> CreateNewAdmin(ApplicationUserViewModel applicationUserViewModel)
        {
            if (applicationUserViewModel != null)
            {
                var newAdmin = new ApplicationUser();
                {
                    newAdmin.FirstName = applicationUserViewModel.FirstName;
                    newAdmin.LastName = applicationUserViewModel.LastName;
                    newAdmin.Email = applicationUserViewModel.Email;
                    newAdmin.UserName = applicationUserViewModel.Email;
                    newAdmin.IsAdmin = true;
                    newAdmin.Deactivated = false;
                    newAdmin.CreatedDate = DateTime.Now.Date;
                }
                var result = await _userManager.CreateAsync(newAdmin, applicationUserViewModel.Password);
                if (result.Succeeded)
                {
                    return newAdmin;

                }
                return null;
            }
            return null;

        }

        public async Task<ApplicationUser> UserLogin(LoginViewModel userr)
        {
            var userToSignIn = await _userManager.FindByEmailAsync(userr.Email);
            if (userToSignIn != null && userToSignIn.Deactivated != true)
            {
                var logger = _signInManager.PasswordSignInAsync(userToSignIn.UserName, userr.Password, true, false).Result;
                if (logger.Succeeded)
                {
                    return userToSignIn;
                }
            }
            return null;
        }


        public async Task<bool> LogOut()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public string GetUserLayout(string email)
        {
            var accountType = _userManager.FindByEmailAsync(email).Result;
            var userRole = _userManager.GetRolesAsync(accountType).Result.FirstOrDefault();
            if (userRole != null)
            {
                if (userRole == "SuperAdmin")
                {
                    return "~/Views/Shared/_SuperAdminLayout.cshtml";

                }
                else if (userRole == "Admin")
                {
                    return "~/Views/Shared/_AdminLayout.cshtml";
                }
                else
                {
                    return "~/Views/Shared/_StudentLayout.cshtml";
                }
            }
            return null;
        }
       
        
        public string GetUserIndex(ApplicationUser userr)
        {
            var userRole = _userManager.GetRolesAsync(userr).Result.FirstOrDefault();
            if (userRole != null)
            {
                if (userRole == "SuperAdmin")
                {
                    return "/SuperAdmin/Index";

                }
                else if (userRole == "Admin")
                {
                    return "/Admin/Index";
                }
                else
                {
                    return "/Employee/Index";
                }
            }
            return null;
        }

    }
}
