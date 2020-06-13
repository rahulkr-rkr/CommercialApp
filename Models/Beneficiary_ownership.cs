using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CommercialApp.Models
{
    public class Beneficiary_ownership
    {
        [Key]
        public int beneficiary_id { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter Phone No")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public long phone { get; set; }
        [Required(ErrorMessage = "Enter role")]
        [Display(Name = "Role In Company")]
        public string role { get; set; }

        //foreign key
        public int business_id { get; set; }
        [ForeignKey("business_id")]
        public virtual Business b_id { get; set; }
    }
}