using Logic.IHelper;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY_MANAGEMENT_SYSTEM.Controllers
{
    public class SuperAdminController : Controller
    {
        private readonly IAccountHelper _accountHelper;

        public SuperAdminController(IAccountHelper accountHelper)
        {
            _accountHelper = accountHelper;
        }
        public IActionResult Index()
        {
            ViewBag.Layout = _accountHelper.GetUserLayout(User.Identity.Name);
            return View();
        }
    }
}
