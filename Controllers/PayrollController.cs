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
    public class PayrollController : Controller
    {
        // GET: Payroll
        [HttpGet]
        public ActionResult PayrollView(string bname)
        {
            Payroll pObj = new Payroll();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string sqlQuery = "select * from BUSINESS where business_name='" + bname + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    pObj.business_id = Convert.ToInt32(sdr["business_id"]);
                    pObj.annual_revenue= Convert.ToInt32(sdr["annual_revenue"]);
                    pObj.no_of_employees= Convert.ToInt32(sdr["number_of_employees"]);
                }
                con.Close();
            }
            return View(pObj);
        }

        [HttpPost]
        public ActionResult PayrollView(Payroll payroll)
        {
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                //using stored procedure
                using (SqlCommand cmd = new SqlCommand("calcul", con))
                {
                    cmd.Connection = con;
                    // opening connection  
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Passing parameter values  
                    cmd.Parameters.AddWithValue("@business_id", payroll.business_id);
                    cmd.Parameters.AddWithValue("@annual_revenue", payroll.annual_revenue);
                    cmd.Parameters.AddWithValue("@aggregate_amount", payroll.aggregate_amount);
                    cmd.Parameters.AddWithValue("@no_of_employees", payroll.no_of_employees);
                    // Executing stored procedure 
                    cmd.ExecuteNonQuery();
                    //status = (cmd.ExecuteNonQuery() >= 1) ? "Record is saved Successfully!" : "Record is not saved";
                    //status += "<br/>";
                    Session["b_id"] = payroll.business_id;
                    return RedirectToAction("PayrollInfoView","PayrollInfo", new { bid = @Session["b_id"] });
                }
                
                con.Close();
            }
            return View();
        }

        public ActionResult PWelcome()
        {
            return View();
        }
    }
}