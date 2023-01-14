using EmployeeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Repositories.Interfaces
{
    public interface IRepository<T> where T : DomainObject
    {
        T Get(int id);
    }
}
