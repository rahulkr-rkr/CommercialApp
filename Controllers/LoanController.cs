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
    public class LoanController : Controller
    {
        // GET: Loan
        /*public ActionResult LoanView()
        {
            return View();
        }*/
        [HttpGet]
        public ActionResult LoanView(string bid)
        {
            Loan lObj = new Loan();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string sqlQuery = "select * from BUSINESS where business_id='" + bid + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    lObj.business_id = Convert.ToInt32(sdr["business_id"]);
                    lObj.applicant_id = Convert.ToInt32(sdr["applicant_id"]);

                }
                con.Close();
            }
            return View(lObj);
        }

        [HttpPost]
        public ActionResult LoanView(Loan loan_data)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertLoanData(loan_data);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                //return View();
                return RedirectToAction("AccountView", "Account", new { bid = @Session["b_id"] });
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
    }
}