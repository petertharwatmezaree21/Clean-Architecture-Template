using CleanArchitecture_Domain.Models;
using CleanArchitecture_Repositry;
using CleanArchitecture_Repositry.ApplicationContext;
using ClearArchitecture_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearArchitecture_Service.Bussiness
{
   public class DepartmentRepositry:Repositry<Department>,IDepartmentRepositry
    {
        public DepartmentRepositry(ApplicationDbContext Context):base(Context)
        {

        }
    }
}
