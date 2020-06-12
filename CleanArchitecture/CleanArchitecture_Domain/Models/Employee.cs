using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Cache;
using System.Text;

namespace CleanArchitecture_Domain.Models
{
   public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
    }
}
