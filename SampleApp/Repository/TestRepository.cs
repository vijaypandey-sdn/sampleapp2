using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Repository
{
    public class TestRepository : ITestRepository
    {
        // this list is acting like your data source.
        readonly List<Employee> employees = new List<Employee>
        {
            new Employee{Name="Ajay",Salary=100000, Department="Engg"},
            new Employee{Name="Vijay", Salary=150000, Department="Testing"},
            new Employee{Name="Vishal",Salary=96000 ,Department="Engg"},
            new Employee{Name="Manish", Salary=850000, Department="Engg"},
            new Employee{Name="Suresh",Salary=9888000, Department="Testing"}
        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
