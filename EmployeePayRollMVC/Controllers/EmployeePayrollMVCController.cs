using BusinessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRollMVC.Controllers
{
    public class EmployeePayrollMVCController : Controller
    {
        private readonly IEmployeeBl employeeBl;
        public EmployeePayrollMVCController(IEmployeeBl employeeBl)
        {
            this.employeeBl = employeeBl;
        }
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeBl.GetAllEmployees().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBl.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeBl.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Employee employee)
        {
            if (id != employee.Emp_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBl.EditEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeBl.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var employee = employeeBl.getEmployeeById(id);
            employeeBl.deleteEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeBl.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Login()
        {
            var employeeLogin = new EmployeeLogin();
            return View(employeeLogin);
        }

        [HttpPost]
        public IActionResult Login([Bind] EmployeeLogin login)
        {

            if (ModelState.IsValid)
            {
                var result = employeeBl.EmpLogin(login);
                if (result != null)
                {
                    HttpContext.Session.SetInt32("Emp_id", result.Emp_id);
                    HttpContext.Session.SetString("Emp_name", result.Emp_name);
                    ViewBag.message = "Sucess login";
                    return RedirectToAction("Details");

                }
                else
                {
                    return View(login);
                }
            }
            return View(login);
        }


    }   
}

