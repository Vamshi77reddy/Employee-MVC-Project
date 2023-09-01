using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Model;


namespace BusinessLayer.Services
{
    public interface IEmployeeBl
    {
        IEnumerable<Employee> GetAllEmployees();

        void AddEmployee(Employee employee);
        Employee getEmployeeById(int? id);

        void EditEmployee(Employee employee);

        public void deleteEmployee(Employee employee);
        public Employee EmpLogin(EmployeeLogin employeeAccount);


    }
}
