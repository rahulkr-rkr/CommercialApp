using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialApp.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CommercialApp.DataAccess;

namespace CommercialApp.Controllers
{
    public class Applicant_AddressController : Controller
    {
        // GET: Applicant_Address
        [HttpGet]
        public ActionResult AAddressView(string aname)
        {
            Applicant_Address applicantaddObj = new Applicant_Address();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string sqlQuery = "select * from APPLICANT where first_name='" + aname + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    applicantaddObj.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
                    applicantaddObj.role = Convert.ToString(sdr["role"]);
                    applicantaddObj.ssn = Convert.ToInt32(sdr["ssn"]);
                }
                con.Close();
            }

            return View(applicantaddObj);
        }

        [HttpPost]
        public ActionResult AAddressView(Applicant_Address app_address)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertAData(app_address);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                //return View();
                return RedirectToAction("PayrollView", "Payroll", new { bname = @Session["business_name"] });
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        public ActionResult AWelcome()
        {
            return View();
        }
    }
}