using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class EmployeeRepository
    {
        private readonly string constr= System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(constr);
            }
        }
        public List<EmployeeModel> GetAllEmp()
        {
            using(IDbConnection con = Connection)
            {
                con.Open();
                return con.Query<EmployeeModel>("sp_GetAll_Emp", null,commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public int Add(EmployeeModel emp)
        {
            using(IDbConnection con=Connection)
            {
                con.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@name", emp.Name);
                param.Add("@designation", emp.Designation);
                param.Add("@email",emp.Email);
                param.Add("@phone",emp.Phone);
                param.Add("@salary",emp.Salary);
                param.Add("@status", 1);
                return con.Execute("sp_EmpAdd", param,commandType:CommandType.StoredProcedure);
            }
        }
        public EmployeeModel GetEmpById(int id)
        {
            using (IDbConnection con = Connection)
            {
                con.Open();
                DynamicParameters param=new DynamicParameters();
                param.Add("@id", id);
                return con.Query<EmployeeModel>("sp_GetEmp_ById",param,commandType:CommandType.StoredProcedure).SingleOrDefault(); 
            }
        }
        public int EditEmp(EmployeeModel emp)
        {
            using (IDbConnection con=Connection)
            {
                con.Open();
                DynamicParameters param=new DynamicParameters();
                param.Add("@id",emp.Id);
                param.Add("@name", emp.Name);
                param.Add("@designation", emp.Designation);
                param.Add("@email", emp.Email);
                param.Add("@phone", emp.Phone);
                param.Add("@salary", emp.Salary);
                return con.Execute("sp_EditEmp",param,commandType:CommandType.StoredProcedure);
            }
        }
        public int UpdateEmp(int id)
        {
            using (IDbConnection con=Connection)
            {
                con.Open();
                DynamicParameters param=new DynamicParameters();
                param.Add("@id", id);
                return con.Execute("sp_UpdateEmp",param, commandType:CommandType.StoredProcedure);
            }
        }
    }
}