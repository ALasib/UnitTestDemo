using EmployeeManagementApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Services
{
    public class TaxService : ITaxService
    {
        public double GetTaxRate()
        {
            return 0.15;
        }
    }
}
