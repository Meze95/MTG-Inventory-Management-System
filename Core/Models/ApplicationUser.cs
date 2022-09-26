using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool Deactivated { get; set; }
        public int? DepartmentId { get; set; }
        [Display(Name = "Department")]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int? BranchId { get; set; }
        [Display(Name = "Branch")]
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
