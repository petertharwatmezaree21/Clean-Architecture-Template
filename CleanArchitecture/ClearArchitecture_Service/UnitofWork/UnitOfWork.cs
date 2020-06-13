using CleanArchitecture_Repositry.ApplicationContext;
using ClearArchitecture_Service.Bussiness;
using ClearArchitecture_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearArchitecture_Service.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;
        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            Employees = new EmployeeRepositry(context);
            Departments = new DepartmentRepositry(context);
        }

        public IEmployeeRepositry Employees { get; private set; }

        public IDepartmentRepositry Departments { get; private set; }

        public void Save()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
