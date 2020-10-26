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
using System.Web;

namespace EmployeeMang.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT EmployeeId, EmployeeName, Department, Convert(varchar(10), DateOfJoining, 120) as DateOfJoining, PhotoFileName FROM EMPLOYEE";
            DataTable dt = new DataTable();
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, sqlCon))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);

            }

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string post(Employee emp)
        {
            try
            {
                string query = @"INSERT INTO EMPLOYEE Values('" + emp.EmployeeName + @"','"+emp.Department+@"','"+emp.DateOfJoining+@"','"+emp.PhotoFileName+@"')";

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

        public string put(Employee emp)
        {
            try
            {
                string query = @"update EMPLOYEE set EmployeeName = '" + emp.EmployeeName + @"','"+emp.Department+@"','"+emp.DateOfJoining+@"','" +emp.PhotoFileName+@"' WHERE EmployeeId = " + emp.EmployeeId + @" ";

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
                string query = @"delete from Employee WHERE EmployeeId = " + id + @" ";

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

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            string query = @"SELECT DepartmentName FROM Departments";
            DataTable dt = new DataTable();
            using (var sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, sqlCon))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);

            }

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        [Route("api/Employee/SaveFile")]
        
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                var fileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + fileName);
                postedFile.SaveAs(physicalPath);

                return fileName;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }

    }
}
