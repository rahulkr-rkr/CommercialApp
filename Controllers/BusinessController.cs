using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialApp.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CommercialApp.Controllers
{
    public class BusinessController : Controller
    {
      
        [HttpGet]
        public ActionResult BusinessView(string name)
        {     
            Business businessObj = new Business();
            string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open(); 
            string sqlQuery = "select * from APPLICANT where first_name='" + name + "'"; 
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {        
              businessObj.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
            }
            sqlcon.Close();
            return View(businessObj); 
        }

        [HttpPost]
        public ActionResult BusinessView(Business business)
        {
            string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // opening connection  
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Hrj_Insert_Business", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            // Passing parameter values  
            cmd.Parameters.AddWithValue("@bname", business.business_name);
            cmd.Parameters.AddWithValue("@itype", business.indsustry_type);
            cmd.Parameters.AddWithValue("@tin", business.tin);
            cmd.Parameters.AddWithValue("@nofemployees", business.number_of_employees);
            cmd.Parameters.AddWithValue("@bentity", business.business_entity_type);
            cmd.Parameters.AddWithValue("@date", business.date_of_establishment);
            cmd.Parameters.AddWithValue("@tamount", business.turnover_amount);
            cmd.Parameters.AddWithValue("@annual_revenue", business.annual_revenue);
            cmd.Parameters.AddWithValue("@applicant_id", business.applicant_id);
            cmd.Parameters.AddWithValue("@Query", 1);
            // Executing stored procedure 
            cmd.ExecuteNonQuery();
            Session["business_name"] = business.business_name;
            return RedirectToAction("BAddressView", "Business_Address", new { bname = @Session["business_name"] });
            sqlcon.Close();
            
            return View();
        }

        public ActionResult BWelcome()
        {
            return View();
        }
    }
}