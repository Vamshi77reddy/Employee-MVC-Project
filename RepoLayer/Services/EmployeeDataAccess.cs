using CommonLayer.Model;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace RepoLayer.Services
{
    
        public class EmployeeDataAccess : IEmployeeRl
        {

            private readonly IConfiguration Configuration;
            public EmployeeDataAccess(IConfiguration Configuration)
            {
                this.Configuration = Configuration;
            }
            public void AddEmployee(Employee employee)
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
                {
                try
                    {
                        SqlCommand cmd = new SqlCommand("addEmployee", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@emp_name", employee.Emp_name);
                        cmd.Parameters.AddWithValue("@profile_img", employee.Profile_img);
                        cmd.Parameters.AddWithValue("@emp_gender", employee.Emp_gender);
                        cmd.Parameters.AddWithValue("@emp_dep", employee.Emp_dep);
                        cmd.Parameters.AddWithValue("@salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@start", employee.start);
                        cmd.Parameters.AddWithValue("@notes", employee.Notes);

                        con.Open();
                        cmd.ExecuteNonQuery();    
                        con.Close();
                    }
                catch (Exception ex)
                {
                    throw ex;
                }
                }
            }   
            public IEnumerable<Employee> GetAllEmployees()
            {
            try
            {
                List<Employee> lstemployee = new List<Employee>();

                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
                {
                    SqlCommand cmd = new SqlCommand("getAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Employee employee = new Employee();

                        employee.Emp_id = Convert.ToInt32(rdr["emp_id"]);
                        employee.Emp_name = rdr["emp_name"].ToString();
                        employee.Profile_img = rdr["profile_img"].ToString();
                        employee.Emp_gender = rdr["emp_gender"].ToString();
                        employee.Emp_dep = rdr["emp_dep"].ToString();
                        employee.Salary = Convert.ToInt32(rdr["salary"]);
                        employee.start = Convert.ToDateTime(rdr["start"]);
                        employee.Notes = rdr["notes"].ToString();


                        lstemployee.Add(employee);
                    }
                    con.Close();
                }

                return lstemployee;
            }
            catch(Exception ex) { throw ex; }
            }
        public Employee getEmployeeById(int? id)
        {
            try
            {
                Employee employee = new Employee();

                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
                {
                    string sqlQuery = "SELECT * FROM employee WHERE emp_id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.Emp_id = Convert.ToInt32(rdr["emp_id"]);
                        employee.Emp_name = rdr["emp_name"].ToString();
                        employee.Profile_img = rdr["profile_img"].ToString();
                        employee.Emp_gender = rdr["emp_gender"].ToString();
                        employee.Emp_dep = rdr["emp_dep"].ToString();
                        employee.Salary = Convert.ToInt32(rdr["salary"]);
                        employee.start = Convert.ToDateTime(rdr["start"]);
                        employee.Notes = rdr["notes"].ToString();

                    }
                }
                return employee;
            }
            catch (Exception ex) { throw ex; }
        }
        public void EditEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
                {
                    {
                        SqlCommand cmd = new SqlCommand("updateEmployee", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@emp_id", employee.Emp_id);
                        cmd.Parameters.AddWithValue("@emp_name", employee.Emp_name);
                        cmd.Parameters.AddWithValue("@profile_img", employee.Profile_img);
                        cmd.Parameters.AddWithValue("@emp_gender", employee.Emp_gender);
                        cmd.Parameters.AddWithValue("@emp_dep", employee.Emp_dep);
                        cmd.Parameters.AddWithValue("@salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@start", employee.start);
                        cmd.Parameters.AddWithValue("@notes", employee.Notes);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }
            }
            catch(Exception ex) { throw ex; }

            }

        public void deleteEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
                {
                    SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", employee.Emp_id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            } catch(Exception ex) { throw ex; }
        }
        public Employee EmpLogin(EmployeeLogin employeeAccount)
        {
            Employee employee = null;
            try
            {

                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("LoginEmp1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@emp_id", employeeAccount.Emp_id);
                    cmd.Parameters.AddWithValue("@emp_name", employeeAccount.Emp_name);
                    var returnparameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    returnparameter.Direction = ParameterDirection.ReturnValue;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        var result = returnparameter.Value;
                        if (result != null && result.Equals(2))
                        {
                            throw new Exception("Employee not present");
                        }
                        if (rdr.Read())
                        {
                            employee = new Employee();
                            employee.Emp_id = Convert.ToInt32(rdr["emp_id"]);
                            employee.Emp_name = rdr["emp_name"].ToString();
                            employee.Profile_img = rdr["profile_img"].ToString();
                            employee.Emp_gender = rdr["emp_gender"].ToString();
                            employee.Emp_dep = rdr["emp_dep"].ToString();
                            employee.Salary = Convert.ToInt32(rdr["salary"]);
                            employee.start = Convert.ToDateTime(rdr["start"]);
                            employee.Notes = rdr["notes"].ToString();

                        }
                    }
                }

                return employee;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
    }

