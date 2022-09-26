using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Products
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int? DepartmentId { get; set; }
        [Display(Name = "Department")]
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public int? BranchId { get; set; }
        [Display(Name = "Branch")]
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
        [Display(Name = "Unit Price")]
        public string UnitPrice { get; set; }
        [Display(Name = "Cost Price")]
        public string CostPrice { get; set; }
        public string BarCode { get; set; }
        public bool IsActive { get; set; }        

    }
}
