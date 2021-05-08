using CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperation.Repository
{
    public class StoreDataRepository
    {   
        string Address = "Data source = DESKTOP-8T78S35; Initial Catalog = CRUDOperation; Integrated Security = SSPI;";
        public void InsertData(EmployeeDetailsModel oEmployeeDetailsModel)
        {
            try
            {
                SqlConnection Connect = new SqlConnection(Address);
                Connect.Open();

                SqlCommand cmd = new SqlCommand("SP_Employee_Data", Connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emp_FName", oEmployeeDetailsModel.EmpFirstName);
                cmd.Parameters.AddWithValue("@Emo_LName", oEmployeeDetailsModel.EmpLastName);
                cmd.Parameters.AddWithValue("@Emp_Mobile", oEmployeeDetailsModel.MobileNo);
                cmd.Parameters.AddWithValue("@Emp_Email", oEmployeeDetailsModel.Email);
                cmd.Parameters.AddWithValue("@Feedback", oEmployeeDetailsModel.Feedback);

                int x = cmd.ExecuteNonQuery();

                Connect.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public List<GetDetailsModel> getDetails()
        {
            List<GetDetailsModel> getList = new List<GetDetailsModel>();
            GetDetailsModel objGetDetailsModel = new GetDetailsModel();
            SqlConnection Connect = new SqlConnection(Address);

            SqlCommand cmd = new SqlCommand("SP_Send_Employee_Data", Connect);
            cmd.CommandType = CommandType.StoredProcedure;
            Connect.Open();

            SqlDataReader read = cmd.ExecuteReader();

            try
            {
                while (read.Read())
                {
                    GetDetailsModel oGetDetailsModel = new GetDetailsModel()
                    {
                        EmpID = Convert.ToInt32(read["Emp_ID"]),
                        EmpFirstName = read["Emp_FName"].ToString(),
                        EmpLastName = read["Emo_LName"].ToString(),
                        MobileNo = read["Emp_Mobile"].ToString(),
                        Email = read["Emp_Email"].ToString(),
                        Feedback = read["Feedback"].ToString()
                    };
                    getList.Add(oGetDetailsModel);
                }

            }
            catch (Exception exe)
            {

            }
            objGetDetailsModel.EmpList = getList;
            return getList;
        }
        public void DeleteEntery( int ID)
        {
            try
            {
                SqlConnection connect = new SqlConnection(Address);
                connect.Open();
                SqlCommand cmd = new SqlCommand("Sp_Delete_Data", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ID);

                int x = cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch(Exception exe)
            {

            }
        }
        public void EditEntery(int ID, EmployeeDetailsModel oEmployeeDetailsModel)
        {
            try
            {
                SqlConnection connect = new SqlConnection(Address); 
                connect.Open();
                SqlCommand cmd = new SqlCommand("Sp_Update_Data", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", ID);
                cmd.Parameters.AddWithValue("@Emp_Mobile", oEmployeeDetailsModel.MobileNo);
                cmd.Parameters.AddWithValue("@Emp_Email", oEmployeeDetailsModel.Email);
                cmd.Parameters.AddWithValue("@Feedback", oEmployeeDetailsModel.Feedback);
                int x = cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception exe)
            {

            }
        }
        public List<GetDetailsModel> GetState()
        {
            List<GetDetailsModel> GetStateList = new List<GetDetailsModel>();

            /*GetDetailsModel objGetDetailsModel = new GetDetailsModel();*/
            SqlConnection Connect = new SqlConnection(Address);

            SqlCommand cmd = new SqlCommand("Sp_StateName", Connect);
            cmd.CommandType = CommandType.StoredProcedure;
            Connect.Open();

            SqlDataReader read1 = cmd.ExecuteReader();

            try
            {
                while (read1.Read())
                {
                    GetDetailsModel oGetDetailsModel = new GetDetailsModel();
                    {
                        oGetDetailsModel.StateID = Convert.ToInt32(read1["State_ID"]);
                        oGetDetailsModel.StateName = read1["State_Name"].ToString();
                    }
                    GetStateList.Add(oGetDetailsModel);

                }
            }
            catch (Exception exe)
            {

            }          
            return GetStateList;
        }
    }
}