using CleanArchitecture_Domain.Models;
using CleanArchitecture_Repositry;
using CleanArchitecture_Repositry.ApplicationContext;
using ClearArchitecture_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClearArchitecture_Service.Bussiness
{
    public class EmployeeRepositry : Repositry<Employee>, IEmployeeRepositry
    {
        public EmployeeRepositry(ApplicationDbContext Context):base(Context)
        {

        }
        public object NumberOfEmployeesInEachLayer()
        {
            return Context.Departments.GroupBy(x => x.DeptName).Select(x => new { DeptName = x.Key, EmpNum = x.Count() });
        }

        public Employee TopEmployeeSalary(decimal Salary)
        {
            return Context.Employees.OrderByDescending(x => x.Salary).Take(1).FirstOrDefault();
        }
    }
}
