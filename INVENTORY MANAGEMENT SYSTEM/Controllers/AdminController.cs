using Core.Data;
using Core.Models;
using Logic.IHelper;
using Microsoft.AspNetCore.Mvc;

namespace INVENTORY_MANAGEMENT_SYSTEM.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountHelper _accountHelper;
        private readonly ApplicationDbContext _db;
        private readonly IAdminHelper _adminHelper;

        public AdminController(IAccountHelper accountHelper, ApplicationDbContext db, IAdminHelper adminHelper)
        {
            _accountHelper = accountHelper;
            _db = db;
            _adminHelper = adminHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Layout = _accountHelper.GetUserLayout(User.Identity.Name);
            return View();
        }
        [HttpGet]
        public IActionResult Employees()
        {
            ViewBag.Layout = _accountHelper.GetUserLayout(User.Identity.Name);
            return View();
        }

        [HttpGet]
        public IActionResult Department()
        {
            ViewBag.Layout = _accountHelper.GetUserLayout(User.Identity.Name);
            var departmentList = _adminHelper.GetAllDepartmentFromTheTable();
            return View(departmentList);
        }

        [HttpPost]
        public JsonResult CreateDepartment(Department newDepartment)
        {
            if (newDepartment.Name == null)
            {
                return Json(new { isError = true, msg = "Enter Department Name" });
            }
            var departmentCheck = _db.Department.Where(d => d.Name == newDepartment.Name).FirstOrDefault();
            if (departmentCheck == null)
            {
                var createdDepartment = _adminHelper.CreateNewDepartment(newDepartment);
                if (createdDepartment != null)
                {
                    return Json(new { isError = false, msg = "Department Created Successfully" });
                }
                return Json(new { isError = true, msg = "Failed" });
            }
            return Json(new { isError = true, msg = "Department Already Exist" });
        }

        [HttpGet]
        public IActionResult Branch()
        {
            ViewBag.Layout = _accountHelper.GetUserLayout(User.Identity.Name);
            var branchList = _adminHelper.GetAllBranchFromTheTable();
            return View(branchList);
        }

        [HttpPost]
        public JsonResult CreateBranch(Branch newBranch)
        {
            if (newBranch.Name == null)
            {
                return Json(new { isError = true, msg = "Enter Branch Name" });
            }
            var branchCheck = _db.Branch.Where(b => b.Name == newBranch.Name).FirstOrDefault();
            if(branchCheck == null)
            {
                var createdBranch = _adminHelper.CreateNewBranch(newBranch);
                if (createdBranch != null)
                {
                    return Json(new { isError = false, msg = "Enter Branch Name" });
                }
                return Json(new { isError = true, msg = "Failed" });
            }
            return Json(new { isError = true, msg = "Branch Already Exist" });
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.Layout = _accountHelper.GetUserLayout(User.Identity.Name);
            return View();
        }
    }
}
