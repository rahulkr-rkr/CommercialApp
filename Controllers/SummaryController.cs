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
    public class SummaryController : Controller
    {
        // GET: Summary
        [HttpGet]
        public ActionResult SummaryView(string bid)
        {
            Summary sObj = new Summary();
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                //business info
                string sqlQuery = "select * from BUSINESS where business_id='" + bid + "'";
                con.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                if (sdr.Read())
                {
                    sObj.business_name = Convert.ToString(sdr["business_name"]);
                    sObj.indsustry_type = Convert.ToString(sdr["industry_type"]);
                    sObj.tin = Convert.ToInt32(sdr["TIN"]);
                    sObj.number_of_employees = Convert.ToInt32(sdr["number_of_employees"]);
                    sObj.business_entity_type = Convert.ToString(sdr["business_entity_type"]);
                    sObj.date_of_establishment = Convert.ToString(sdr["date_of_establishment"]);
                    sObj.turnover_amount = Convert.ToInt32(sdr["turnover_amount"]);
                    sObj.annual_revenue = Convert.ToInt32(sdr["annual_revenue"]);
                }
                con.Close();

                //business addresss
                string sql2Query = "select * from BUSINESS_ADDRESS where business_id='" + bid + "'";
                con.Open();
                SqlCommand sql2Cmd = new SqlCommand(sql2Query, con);
                SqlDataReader sdr2 = sql2Cmd.ExecuteReader();
                if (sdr2.Read())
                {
                    sObj.bstreet_address = Convert.ToString(sdr2["street_address"]);
                    sObj.bcity = Convert.ToString(sdr2["city"]);
                    sObj.bstate = Convert.ToString(sdr2["state"]);
                    sObj.bzipcode = Convert.ToInt32(sdr2["zipcode"]);
                }
                con.Close();

                //payroll info
                string sql3Query = "select * from PAYROLL where business_id='" + bid + "'";
                con.Open();
                SqlCommand sql3Cmd = new SqlCommand(sql3Query, con);
                SqlDataReader sdr3 = sql3Cmd.ExecuteReader();
                if (sdr3.Read())
                {
                    sObj.annual_payroll = Convert.ToInt32(sdr3["annual_payroll"]);
                    sObj.monthly_payroll = Convert.ToInt32(sdr3["monthly_payroll"]);
                }
                con.Close();

                //loan details
                string sql4Query = "select * from LOAN where business_id='" + bid + "'";
                con.Open();
                SqlCommand sql4Cmd = new SqlCommand(sql4Query, con);
                SqlDataReader sdr4 = sql4Cmd.ExecuteReader();
                if (sdr4.Read())
                {
                    sObj.loan_term = Convert.ToInt32(sdr4["loan_term"]);
                    sObj.interest_rate = Convert.ToInt32(sdr4["interest_rate"]);
                    sObj.borrowed_date = Convert.ToString(sdr4["borrowed_date"]);
                    sObj.deadline_date = Convert.ToString(sdr4["deadline_date"]);
                    sObj.loan_status = Convert.ToString(sdr4["loan_status"]);
                }
                con.Close();

                //beneficial details
                string sql5Query = "select * from BENEFICIARY_OWNERSHIP where business_id='" + bid + "'";
                con.Open();
                SqlCommand sql5Cmd = new SqlCommand(sql5Query, con);
                SqlDataReader sdr5 = sql5Cmd.ExecuteReader();
                if (sdr5.Read())
                {
                    sObj.bofirst_name = Convert.ToString(sdr5["first_name"]);
                    sObj.bolast_name = Convert.ToString(sdr5["last_name"]);
                    sObj.boemail = Convert.ToString(sdr5["email"]);
                    sObj.bophone = Convert.ToInt32(sdr5["phone_number"]);
                    sObj.borole = Convert.ToString(sdr5["role"]);
                }
                con.Close();

                //applicant details
                string sql6Query = "select * from BUSINESS where business_id='" + bid + "'";
                con.Open();
                SqlCommand sql6Cmd = new SqlCommand(sql6Query, con);
                SqlDataReader sdr6 = sql6Cmd.ExecuteReader();
                if (sdr6.Read())
                {
                    Session["aid"] = Convert.ToInt32(sdr6["applicant_id"]);
                    
                }
                con.Close();

                string sql7Query = "select * from APPLICANT where applicant_id='" + Session["aid"] + "'";
                con.Open();
                SqlCommand sql7Cmd = new SqlCommand(sql7Query, con);
                SqlDataReader sdr7 = sql7Cmd.ExecuteReader();
                if (sdr7.Read())
                {
                    sObj.applicant_id = Convert.ToInt32(sdr7["applicant_id"]);
                    sObj.first_name = Convert.ToString(sdr7["first_name"]);
                    sObj.last_name = Convert.ToString(sdr7["last_name"]);
                    sObj.email = Convert.ToString(sdr7["email"]);
                    sObj.phone = Convert.ToInt64(sdr7["phone_number"]);
                    sObj.role = Convert.ToString(sdr7["role"]);
                    sObj.ssn = Convert.ToInt32(sdr7["SSN"]);
                }
                con.Close();

                //applicant address
                string sql8Query = "select * from APPLICANT_ADDRESS where applicant_id='" + Session["aid"] + "'";
                con.Open();
                SqlCommand sql8Cmd = new SqlCommand(sql8Query, con);
                SqlDataReader sdr8 = sql8Cmd.ExecuteReader();
                if (sdr8.Read())
                {
                    sObj.street_address = Convert.ToString(sdr8["street_address"]);
                    sObj.city = Convert.ToString(sdr8["city"]);
                    sObj.state = Convert.ToString(sdr8["state"]);
                    sObj.zipcode = Convert.ToInt32(sdr8["zipcode"]);
                }
                con.Close();

                //account details
                string sql9Query = "select * from ACCOUNTT where applicant_id='" + Session["aid"] + "'";
                con.Open();
                SqlCommand sql9Cmd = new SqlCommand(sql9Query, con);
                SqlDataReader sdr9 = sql9Cmd.ExecuteReader();
                if (sdr9.Read())
                {
                    sObj.account_number = Convert.ToString(sdr9["account_number"]);
                    sObj.bank_name = Convert.ToString(sdr9["bank_name"]);
                    sObj.account_holder_name = Convert.ToString(sdr9["account_holder_name"]);
                    sObj.isfc = Convert.ToString(sdr9["IFSC"]);
                    sObj.mode_of_transfer = Convert.ToString(sdr9["mode_of_transfer"]);
                }
                con.Close();
            }
            return View(sObj);
        }
        [HttpPost]
        public ActionResult SummaryView()
        {
            return RedirectToAction("success");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}