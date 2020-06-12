using CleanArchitecture_Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CleanArchitecture_Domain.Validation
{
   public class DepartmentFulentApi
    {
        public DepartmentFulentApi(EntityTypeBuilder<Department> entityBuilder)
        {
            entityBuilder.HasKey(d => d.Id);
            entityBuilder.HasMany<Employee>(x => x.Employees).WithOne("Department");

        }
    }
}
