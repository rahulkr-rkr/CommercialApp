using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class PayrollInfo
    {
        [Display(Name = "Annual Payroll")]
        public int annual_payroll { get; set; }
        [Display(Name = "Monthly Payroll")]
        public int monthly_payroll { get; set; }
        [Display(Name = "Business_id")]
        public int business_id { get; set; }

    }
}