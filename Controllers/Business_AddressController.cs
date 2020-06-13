using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialApp.Models;
using System.Configuration;
using System.Data.SqlClient;
using CommercialApp.DataAccess;


namespace CommercialApp.Controllers
{
    public class Business_AddressController : Controller
    {
        // GET: Business_Address
        [HttpGet]
        public ActionResult BAddressView(string bname)
        {
            Business_Address businessaddObj = new Business_Address();
            string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            sqlcon.Open();
            string sqlQuery = "select * from BUSINESS where business_name='" + bname + "'";
            SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlcon);
            SqlDataReader sdr = sqlCmd.ExecuteReader();
            if (sdr.Read())
            {
              businessaddObj.business_id = Convert.ToInt32(sdr["business_id"]);
            }
            sqlcon.Close();
            return View(businessaddObj);
        }

        [HttpPost]
        public ActionResult BAddressView(Business_Address Bu_address)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(Bu_address);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                //return View();
                return RedirectToAction("AAddressView", "Applicant_Address", new { aname = @Session["first_name"] });
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        public ActionResult BAWelcome()
        {
            return View();
        }
    }
}