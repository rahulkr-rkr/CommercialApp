using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using CommercialApp.Models;
using System.Data;

namespace CommercialApp.DataAccess
{
    public class DataAccessLayer
    {
        public string InsertData(Business_Address Bu_add)
        {
            string result = "";
            string con = ConfigurationManager.ConnectionStrings["commercialDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // opening connection  
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("Usp_Insert_Business_Address", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@saddress", Bu_add.street_address);
            cmd.Parameters.AddWithValue("@city", Bu_add.city);
            cmd.Parameters.AddWithValue("@state", Bu_add.state);
            cmd.Parameters.AddWithValue("@zipcode", Bu_add.zipcode);
            cmd.Parameters.AddWithValue("@business_id", Bu_add.business_id);
            cmd.Parameters.AddWithValue("@Query", 1);
            cmd.ExecuteNonQuery();  
            sqlcon.Close();
            
            return result;
        }

        public string InsertAData(Applicant_Address app_add)
        {
            string result = "";
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string query = "INSERT INTO APPLICANT_ADDRESS(street_address,city,state,zipcode,applicant_id) VALUES(@saddress, @city, @state, @zipcode, @applicant_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    // opening connection  
                    con.Open();
                    cmd.Parameters.AddWithValue("@saddress", app_add.street_address);
                    cmd.Parameters.AddWithValue("@city", app_add.city);
                    cmd.Parameters.AddWithValue("@state", app_add.state);
                    cmd.Parameters.AddWithValue("@zipcode", app_add.zipcode);
                    cmd.Parameters.AddWithValue("@applicant_id", app_add.applicant_id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return result;
        }

        public string InsertLoanData(Loan loan)
        {
            string result = "";
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string query = "INSERT INTO LOAN(loan_term,interest_rate,borrowed_date,deadline_date,loan_status,applicant_id,business_id) VALUES(@term, @rate, @bdate, @ddate,@status,@applicant_id,@business_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    // opening connection  
                    con.Open();
                    cmd.Parameters.AddWithValue("@term", loan.loan_term);
                    cmd.Parameters.AddWithValue("@rate", loan.interest_rate);
                    cmd.Parameters.AddWithValue("@bdate", loan.borrowed_date);
                    cmd.Parameters.AddWithValue("@ddate", loan.deadline_date);
                    cmd.Parameters.AddWithValue("@status", loan.loan_status);
                    cmd.Parameters.AddWithValue("@applicant_id", loan.applicant_id);
                    cmd.Parameters.AddWithValue("@business_id", loan.business_id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return result;
        }

        public string InsertAccountData(Account acc)
        {
            string result = "";
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string query = "INSERT INTO ACCOUNTT(account_number,bank_name,account_holder_name,IFSC,mode_of_transfer,applicant_id,loan_id) VALUES(@acc_no, @bname, @ahname, @ifsc,@mtransfer,@applicant_id,@loan_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    // opening connection  
                    con.Open();
                    cmd.Parameters.AddWithValue("@acc_no", acc.account_number);
                    cmd.Parameters.AddWithValue("@bname", acc.bank_name);
                    cmd.Parameters.AddWithValue("@ahname", acc.account_holder_name);
                    cmd.Parameters.AddWithValue("@ifsc", acc.isfc);
                    cmd.Parameters.AddWithValue("@mtransfer", acc.mode_of_transfer);
                    cmd.Parameters.AddWithValue("@applicant_id", acc.applicant_id);
                    cmd.Parameters.AddWithValue("@loan_id", acc.loan_id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return result;
        }

        public string InsertBeneficiaryData(Beneficiary_ownership bo)
        {
            string result = "";
            using (SqlConnection con = new SqlConnection("Data Source=RAHUL\\SQLEXPRESS01;Initial Catalog=Commercial;Integrated Security=True"))
            {
                string query = "INSERT INTO BENEFICIARY_OWNERSHIP(first_name,last_name,email,phone_number,role,business_id) VALUES(@fname, @lname, @email, @phone,@role,@business_id)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Connection = con;
                    // opening connection  
                    con.Open();
                    cmd.Parameters.AddWithValue("@fname", bo.first_name);
                    cmd.Parameters.AddWithValue("@lname", bo.last_name);
                    cmd.Parameters.AddWithValue("@email", bo.email);
                    cmd.Parameters.AddWithValue("@phone", bo.phone);
                    cmd.Parameters.AddWithValue("@role", bo.role);
                    cmd.Parameters.AddWithValue("@business_id", bo.business_id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return result;
        }
    }
}