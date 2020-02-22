using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Modules
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name="部门名称")]
        public String Name { get; set; }
        [Display(Name = "部门地址")]
        public String Location { get; set; }
        [Display(Name = "部门人数")]
        public int EmployeeCount { get; set; }
    }
}
