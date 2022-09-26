using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.IHelper
{
    public interface IAdminHelper
    {
        public Branch CreateNewBranch(Branch newBranch);
        public List<Branch> GetAllBranchFromTheTable();
        public Department CreateNewDepartment(Department newDepartment);
        public List<Department> GetAllDepartmentFromTheTable();
    }
}
