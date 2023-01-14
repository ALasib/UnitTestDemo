using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Services.Interfaces
{
    public interface IEmployeeService
    {
        double CalculateTax(int employeeId, DateTime to);
    }
}
