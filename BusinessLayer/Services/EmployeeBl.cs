using CommonLayer.Model;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLayer.Services
{
    public class EmployeeBl : IEmployeeBl
    {
        IEmployeeRl employeeRl;

        public EmployeeBl(IEmployeeRl employeeRl)
        {
            this.employeeRl = employeeRl;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                this.employeeRl.AddEmployee(employee);
            }
            catch (Exception e){ throw e; }
            
        }
        public void EditEmployee(Employee employee)
        {
            try
            {
                this.employeeRl.EditEmployee(employee);
            }
            catch (Exception e) { throw e; }    
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
               return this.employeeRl.GetAllEmployees();
            }
            catch (Exception e) { throw e; }    
        }
        public void deleteEmployee(Employee employee)
        {
            try
            {
                this.employeeRl.deleteEmployee(employee);
            }
            catch (Exception e) { throw e; }    
        }
        public Employee getEmployeeById(int? id)
        {
            try
            {
                return this.employeeRl.getEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Employee EmpLogin(EmployeeLogin employeeAccount)
        {
            try
            {
                return this.employeeRl.EmpLogin(employeeAccount);
            }
            catch (Exception e) { throw e; }    
        }


    }
}


   