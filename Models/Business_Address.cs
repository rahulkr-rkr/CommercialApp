using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CommercialApp.Models
{
    public class Business_Address
    {
        [Display(Name = "Street addresss")]
        public string street_address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
         public string state { get; set; }
       
        [Display(Name = "Zip Code")]
        public int zipcode { get; set; }
        //foreign key
        public int business_id { get; set; }
        [ForeignKey("business_id")]
        public virtual Business b_id { get; set; }
    }
}