using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Applicant_Address
    {
        [Display(Name = "Role In Company")]
        public string role { get; set; }
        [Display(Name = "SSN")]
        public long ssn { get; set; }
        [Display(Name = "Street addresss")]
        public string street_address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        public int zipcode { get; set; }
        //foreign key
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual Applicant a_id { get; set; }
    }
}