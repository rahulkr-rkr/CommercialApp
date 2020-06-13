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
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult ApplicantView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplicantView(Applicant applicant)
        {
            string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // opening connection  
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Hrj_InsertUpdateDelete_Applicant", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            // Passing parameter values  
            cmd.Parameters.AddWithValue("@fname", applicant.first_name);
            cmd.Parameters.AddWithValue("@lname", applicant.last_name);
            cmd.Parameters.AddWithValue("@email", applicant.email);
            cmd.Parameters.AddWithValue("@phone", applicant.phone);
            cmd.Parameters.AddWithValue("@role", applicant.role);
            cmd.Parameters.AddWithValue("@ssn", applicant.ssn);
            cmd.Parameters.AddWithValue("@Query", 1);
            // Executing stored procedure 
            cmd.ExecuteNonQuery();
            Session["first_name"] = applicant.first_name;
            return RedirectToAction("BusinessView", "Business", new { name = @Session["first_name"] });
            sqlcon.Close();
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}