using CleanArchitecture_Domain.Models;
using CleanArchitecture_Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearArchitecture_Service.Interfaces
{
    //Here in this Interface will put all other method that we neeed
    // like the top employee salary 
    // number of employees in each departement
   public interface IEmployeeRepositry:IRepositry<Employee>
    {
        Employee TopEmployeeSalary(decimal Salary);
       object NumberOfEmployeesInEachLayer();

    }
}
