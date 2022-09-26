using Core.Data;
using Core.Models;
using Logic.IHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helper
{
    public class AdminHelper: IAdminHelper
    {
        private readonly ApplicationDbContext _db;

        public AdminHelper(ApplicationDbContext db)
        {
            _db = db;
        }
        // CREATE NEW BRANCH
        public Branch CreateNewBranch(Branch newBranch)
        {
            if(newBranch != null)
            {
                var newBranchToBeCreated = new Branch
                {
                    Name = newBranch.Name,
                    DateCreated = DateTime.Now,
                    Deactivated = false,
                };

                _db.Branch.Add(newBranchToBeCreated);
                _db.SaveChanges();

                return newBranchToBeCreated;
            }
            return null;
        }

        // LIST OF ALL BRANCH
        public List<Branch> GetAllBranchFromTheTable()
        {
            var allBranch = _db.Branch.Where(b => b.Deactivated == false && b.Id > 0).ToList();
            if (allBranch.Any())
            {
                return allBranch;
            }
            return allBranch;
        }

        // CREATE NEW DEPARTMENT
        public Department CreateNewDepartment(Department newDepartment)
        {
            if (newDepartment != null)
            {
                var newDepartmentToBeCreated = new Department
                {
                    Name = newDepartment.Name,
                    DateCreated = DateTime.Now,
                    Deactivated = false,
                };

                _db.Department.Add(newDepartmentToBeCreated);
                _db.SaveChanges();

                return newDepartmentToBeCreated;
            }
            return null;
        }

        // LIST OF ALL DEPARTMENT
        public List<Department> GetAllDepartmentFromTheTable()
        {
            var allDepartment = _db.Department.Where(d => d.Deactivated == false && d.Id > 0).ToList();
            if (allDepartment.Any())
            {
                return allDepartment;
            }
            return allDepartment;
        }
    }
}
