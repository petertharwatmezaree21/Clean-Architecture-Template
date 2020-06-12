using CleanArchitecture_Domain.Models;
using CleanArchitecture_Domain.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture_Repositry.ApplicationContext
{
   public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EmployeeFluentApi(modelBuilder.Entity<Employee>());
            new DepartmentFulentApi (modelBuilder.Entity<Department>());
        }
    }
}
