using ClearArchitecture_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearArchitecture_Service.UnitofWork
{
  public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepositry Employees { get; }
        IDepartmentRepositry Departments { get; }

        void Save();
    }
}
