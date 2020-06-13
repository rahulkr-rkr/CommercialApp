using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    public class Business
    {
        [Key]
        public int business__id { get; set; }

        [Required(ErrorMessage = "Enter Business Name")]
        [Display(Name = "Business Name")]
        public string business_name { get; set; }
        [Required(ErrorMessage = "Give Industry Type")]
        [Display(Name = "Industry Type")]
        public string indsustry_type { get; set; }
        
        [Display(Name = "Tax Identification Number")]
        public int tin { get; set; }
        [Required(ErrorMessage = "Give Number of Employees")]
        [Display(Name = "Number of Employees")]
        public int number_of_employees { get; set; }
        
        [Display(Name = "Business Entity Type")]
        public string business_entity_type { get; set; }
        
        [Display(Name = "Date Of Establishment")]
        public string date_of_establishment { get; set; }
        
        [Display(Name = "Turnover Amount")]
        public int turnover_amount { get; set; }
        [Required(ErrorMessage = "It is an Required field")]
        [Display(Name = "Annual Revenue")]
        public int annual_revenue { get; set; }
        //foreign key
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public virtual Applicant applicants { get; set; }
    }
}