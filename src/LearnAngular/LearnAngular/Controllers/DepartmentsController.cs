using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnAngular.Models;

namespace LearnAngular.Controllers
{
    public class DepartmentsController : ApiController
    {
        [HttpGet]
        [Route("api/v1/departments/test")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Success");
        }


        [HttpGet]
        [Route("api/v1/departments")]
        public HttpResponseMessage GetDepartments()
        {
            string query = @"select DepartmentId, DepartmentName from dbo.Department";
            DataTable table = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, connection))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, table);
        }

        [HttpPost]
        [Route("api/v1/departments/save")]
        public string SaveDepartments(Department department)
        {
            string query = $"insert into dbo.Department values ('{department.DepartmentName}');";

            DataTable table = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, connection))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return "Added successfully";
        }


        [HttpPut]
        [Route("api/v1/departments/update")]
        public HttpResponseMessage EditDepartments(Department department)
        {
            string query = $"update dbo.Department set DepartmentName = '{department.DepartmentName}' where DepartmentId = {department.DepartmentId};";

            DataTable table = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, connection))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }


            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Edited Successfully");
        }


        [HttpDelete]
        [Route("api/v1/departments/delete/{departmentId}")]
        public HttpResponseMessage DeleteDepartments(int departmentId)
        {
            string query = $"delete from dbo.Department where DepartmentId = '{departmentId}';";

            DataTable table = new DataTable();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, connection))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }


            return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Deleted Successfully");
        }
    }
}
