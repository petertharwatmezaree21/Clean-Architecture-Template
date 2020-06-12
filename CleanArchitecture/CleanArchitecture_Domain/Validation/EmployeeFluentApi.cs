using CleanArchitecture_Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CleanArchitecture_Domain.Validation
{
  public  class EmployeeFluentApi
    {
        public EmployeeFluentApi(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(x => x.Salary).IsRequired();
            entityBuilder.HasOne<Department>(x => x.Department).WithMany("Employees").HasForeignKey(x => x.DeptId);
        }
    }
}
