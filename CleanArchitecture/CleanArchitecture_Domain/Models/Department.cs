using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture_Domain.Models
{
  public class Department:BaseEntity
    {
        public string DeptName { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
