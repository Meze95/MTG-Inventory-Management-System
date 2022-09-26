using Core.Models;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IHelper
{
    public interface IAccountHelper
    {
        Task<ApplicationUser> CreateNewAdmin(ApplicationUserViewModel applicationUserViewModel);
        Task<ApplicationUser> UserLogin(LoginViewModel userr);
        Task<bool> LogOut();
        public string GetUserLayout(string email);
        public string GetUserIndex(ApplicationUser userr);
    }
}
