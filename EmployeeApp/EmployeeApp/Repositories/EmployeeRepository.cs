using EmployeeApp.Models;
using EmployeeApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static List<Employee> employees = new List<Employee>
        {
            new Employee{Id = 1, Name="John Doe", JoiningDate=DateTime.Parse("1/1/2018"), Salary = 1000},
            new Employee{Id = 1, Name="John Spencer", JoiningDate=DateTime.Parse("2/1/2018"), Salary = 3000},
            new Employee{Id = 1, Name="Anna Smith", JoiningDate=DateTime.Parse("4/1/2018"), Salary = 2000}
        };
        public Employee Get(int id)
        {
            return employees.Find(employee => employee.Id == id);
        }
    }
}
