using EmployeeApp.Repositories.Interfaces;
using EmployeeApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITaxService _taxService;

        public EmployeeService(IEmployeeRepository employeeRepository, 
                               ITaxService taxService)
        {
            _employeeRepository = employeeRepository;
            _taxService = taxService;
        }

        public double CalculateTax(int employeeId, DateTime to)
        {
            var employee = _employeeRepository.Get(employeeId);
            var totalMonth = ((to - employee.JoiningDate).TotalDays + 1) / 30;
            var totalSalary = totalMonth * employee.Salary;
            return totalSalary * _taxService.GetTaxRate();
        }
    }
}
