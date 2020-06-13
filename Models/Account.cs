using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Account
    {
        [Key]
        public int acc__id { get; set; }
        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "It is an Required field")]
        public string account_number { get; set; }
        [Display(Name = "Bank Name")]
        public string bank_name { get; set; }
        [Display(Name = "Account Holder Name")]
        public string account_holder_name { get; set; }
        [Display(Name = "IFSC Code")]
        public string isfc { get; set; }
        [Display(Name = "Mode Of Transfer")]
        public string mode_of_transfer { get; set; }
        //foreign keys
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual Applicant applicants { get; set; }
        public int loan_id { get; set; }
        [ForeignKey("loan_id")]
        public virtual Loan l_id { get; set; }
    }
}