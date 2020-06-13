using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialApp.Models;
using System.Configuration;
using System.Data.SqlClient;
using CommercialApp.DataAccess;
using System.Data;


namespace CommercialApp.Controllers
{
    public class BeneficiaryController : Controller
    {
        // GET: Beneficiary
        [HttpGet]
        public ActionResult BeneficiaryOwnerView(string bid)
        {
            Beneficiary_ownership boObj = new Beneficiary_ownership();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string sqlQuery = "select * from BUSINESS where business_id='" + bid + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    boObj.business_id = Convert.ToInt32(sdr["business_id"]);
                }
                con.Close();
            }
            return View(boObj);
        }

        [HttpPost]
        public ActionResult BeneficiaryOwnerView(Beneficiary_ownership BO)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertBeneficiaryData(BO);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                //return View();
                return RedirectToAction("SummaryView", "Summary", new { bid = @Session["b_id"] });
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
    }
}