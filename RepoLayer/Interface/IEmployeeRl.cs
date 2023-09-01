using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmployeeRl
    {
        void AddEmployee(Employee employee);
        void EditEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployees();
        void deleteEmployee(Employee employee);

        Employee getEmployeeById(int? id);
        Employee EmpLogin(EmployeeLogin employeeAccount);



    }
}
