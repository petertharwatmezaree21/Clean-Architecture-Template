using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanArchitecture_Web.Models;
using ClearArchitecture_Service.Interfaces;
using CleanArchitecture_Web.ViewModels;
using ClearArchitecture_Service.UnitofWork;
using CleanArchitecture_Domain.Models;

namespace CleanArchitecture_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentRepositry DeptService;
        private readonly IEmployeeRepositry EmpService;
        private readonly IUnitOfWork UnitofWork;

        public HomeController(ILogger<HomeController> logger, IDepartmentRepositry deptService, IEmployeeRepositry empService, IUnitOfWork unitofWork)
        {
            _logger = logger;
            DeptService = deptService;
            EmpService = empService;
            UnitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            
            return View(UnitofWork.Employees.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(EmpService.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee emp)
        {
            var employee = EmpService.Get(id);

            employee.Name = emp.Name;
            employee.Salary = emp.Salary;

            UnitofWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            List<EmployeeDepartmentVM> model = new List<EmployeeDepartmentVM>();
            EmpService.GetAll().ToList().ForEach(emp =>
            {
                var DetName = DeptService.Get(emp.DeptId).DeptName;
                model.Add(new EmployeeDepartmentVM { DeptName = DetName, Name = emp.Name, Salary = emp.Salary });
            });
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
