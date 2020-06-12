using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestProject
{
    class BaseEntity
    {
        public int Id { get; set; }
    }
    class Department:BaseEntity
    {
        public string DeptName { get; set; }
        public IEnumerable<Employee>  Employees { get; set; }
    }
    class Employee:BaseEntity
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        
        public Department Department { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Department Dept1 = new Department
            {
                DeptName = "Dept1",
                Id = 1,
                Employees = new List<Employee> {
                    new Employee {Id=1,Name="Peter1",Salary=5000 },
                    new Employee {Id=2,Name="Peter2",Salary=2000 },
                    new Employee {Id=3,Name="Peter3",Salary=1000 },

                    }
            };

            Department Dept2 = new Department
            {
                DeptName = "Dept2",
                Id = 2,
                Employees = new List<Employee> {
                    new Employee {Id=4,Name="Peter4",Salary=5000 },
                    new Employee {Id=5,Name="Peter5",Salary=2000 },
                   

                    }
            };
            Department Dept3 = new Department
            {
                DeptName = "Dept3",
                Id = 3,
                Employees = new List<Employee> {
                    new Employee {Id=6,Name="Peter6",Salary=5000 },
                    
                   

                    }
            };

           

           


            var empsNumber = Deps.GroupBy(x => x.DeptName).Select(x => new { DeptName = x.Key, EmpsCount = x.Count() });

            foreach (var item in empsNumber)
            {
                Console.WriteLine(string.Format("Department Name {0} - Numberof Employee in It {1} ",item.DeptName,item.EmpsCount));
            }




        }
    }
}
