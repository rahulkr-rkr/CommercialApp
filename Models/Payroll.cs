using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Payroll
    {
        [Display(Name = "Annual Revenue")]
        public int annual_revenue { get; set; }
        [Display(Name = "Number Of Employees")]
        public long no_of_employees { get; set; }
        [Display(Name = "Individual Salary")]
        public int aggregate_amount { get; set; }
        [Display(Name = "Annual Payroll")]
       public int annual_payroll { get; set; }
       [Display(Name = "Monthly Payroll")]
        public int monthly_payroll { get; set; }
        //foreign key
        public int business_id { get; set; }
        [ForeignKey("business_id")]
        public virtual Business b_id { get; set; }
    }
}