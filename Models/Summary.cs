using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Summary
    {
        //Applicant details
        [Display(Name = "Your Application ID")]
        public int applicant_id { get; set; }  
        [Display(Name = "First Name")]
        public string first_name { get; set; }
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
        [Display(Name = "Email Address")]
        public string email { get; set; }
        [Display(Name = "Phone Number")]
        public long phone { get; set; }
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

        //business details
        [Display(Name = "Business Name")]
        public string business_name { get; set; }
        [Display(Name = "Industry Type")]
        public string indsustry_type { get; set; }
        [Display(Name = "Tax Identification Number")]
        public int tin { get; set; }
        [Display(Name = "Number of Employees")]
        public int number_of_employees { get; set; }
        [Display(Name = "Business Entity Type")]
        public string business_entity_type { get; set; }
        [Display(Name = "Date Of Establishment")]
        public string date_of_establishment { get; set; }
        [Display(Name = "Turnover Amount")]
        public int turnover_amount { get; set; }
        [Display(Name = "Annual Revenue")]
        public int annual_revenue{get; set; }
        [Display(Name = "Street addresss")]
        public string bstreet_address { get; set; }
        [Display(Name = "City")]
        public string bcity { get; set; }
        [Display(Name = "State")]
        public string bstate { get; set; }
        [Display(Name = "Zip Code")]
        public int bzipcode { get; set; }

        //payroll information
        [Display(Name = "Annual Payroll")]
        public int annual_payroll { get; set; }
        [Display(Name = "Monthly Payroll")]
        public int monthly_payroll { get; set; }

        //loan information
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

        //account details
        [Display(Name = "Account Number")]
        public string account_number { get; set; }
        [Display(Name = "Bank Name")]
        public string bank_name { get; set; }
        [Display(Name = "Account Holder Name")]
        public string account_holder_name { get; set; }
        [Display(Name = "IFSC Code")]
        public string isfc { get; set; }
        [Display(Name = "Mode Of Transfer")]
        public string mode_of_transfer { get; set; }

        //beneficiary ownership details
       
        [Display(Name = "First Name")]
        public string bofirst_name { get; set; }
       
        [Display(Name = "Last Name")]
        public string bolast_name { get; set; }
        
        [Display(Name = "Email Address")]
        
        public string boemail { get; set; }
       
        [Display(Name = "Phone Number")]
       
        public long bophone { get; set; }
       
        [Display(Name = "Role In Company")]
        public string borole { get; set; }
    }
}