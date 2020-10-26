using EmployeeMang.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeMang.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM DEPARTMENTS";
            DataTable dt = new DataTable();
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString)) 
            using(var cmd = new SqlCommand(query, sqlCon))
            using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);

            }

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string post(Departments dept)
        {
            try
            {
                string query = @"INSERT INTO DEPARTMENTS Values('"+dept.DepartmentName+@"')";

                DataTable dt = new DataTable();
                using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, sqlCon))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);

                }

                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add!";
            }
        }

        public string put(Departments dept)
        {
            try
            {
                string query = @"update DEPARTMENTS set DepartmentName = '" + dept.DepartmentName + @"' WHERE DepartmentId = "+dept.DepartmentId+@" ";

                DataTable dt = new DataTable();
                using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, sqlCon))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);

                }

                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed to Update!";
            }
        }

        public string delete(int id)
        {
            try
            {
                string query = @"delete from DEPARTMENTS WHERE DepartmentId = " + id + @" ";

                DataTable dt = new DataTable();
                using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, sqlCon))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);

                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to delete!";
            }
        }

    }
}
