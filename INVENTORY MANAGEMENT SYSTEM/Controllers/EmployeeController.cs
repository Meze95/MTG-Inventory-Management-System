using Logic.IHelper;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY_MANAGEMENT_SYSTEM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAccountHelper _accountHelper;

        public EmployeeController(IAccountHelper accountHelper)
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
