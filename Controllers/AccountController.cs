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
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult AccountView(string bid)
        {
            Account aObj = new Account();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string sqlQuery = "select * from LOAN where business_id='" + bid + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                   
                    aObj.applicant_id = Convert.ToInt32(sdr["applicant_id"]);
                    aObj.loan_id = Convert.ToInt32(sdr["loan_id"]);

                }
                con.Close();
            }
            return View(aObj);
        }

        [HttpPost]
        public ActionResult AccountView(Account account)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertAccountData(account);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                //return View();
                return RedirectToAction("BeneficiaryOwnerView", "Beneficiary", new { bid = @Session["b_id"] });
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
    }
}