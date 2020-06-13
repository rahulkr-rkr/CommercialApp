using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Loan
    {
        [Key]
        public int loan__id { get; set; }
        [Display(Name = "Loan Term")]
        public int loan_term { get; set; }
        [Display(Name = "Interest Rate")]
        public int interest_rate { get; set; }
        [Display(Name = "Borrowed Date")]
        public string borrowed_date { get; set; }
        [Display(Name = "Deadline Date")]
        public string deadline_date { get; set; }
        [Display(Name = "Loan Status")]
        public string loan_status { get; set; }
        //foreign keys
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual Applicant applicants { get; set; }
        public int business_id { get; set; }
        [ForeignKey("business_id")]
        public virtual Business b_id { get; set; }
    }
}