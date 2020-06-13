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
    public class PayrollInfoController : Controller
    {
        // GET: PayrollInfo
        [HttpGet]
        public ActionResult PayrollInfoView(string bid)
        {
            PayrollInfo piObj = new PayrollInfo();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string sqlQuery = "select * from PAYROLL where business_id='" + bid + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    piObj.business_id = Convert.ToInt32(sdr["business_id"]);
                    piObj.annual_payroll = Convert.ToInt32(sdr["annual_payroll"]);
                    piObj.monthly_payroll = Convert.ToInt32(sdr["monthly_payroll"]);
                }
                con.Close();
            }
            return View(piObj);
        }
        [HttpPost]
        public ActionResult PayrollInfoView()
        {
            return RedirectToAction("LoanView", "Loan", new { bid = @Session["b_id"] });
        }
    }
}