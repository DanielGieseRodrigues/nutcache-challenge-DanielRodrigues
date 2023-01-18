using ConEmployeeRegistratationtatos.Domain.Interfaces;
using EmployeeRegistratation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistratation.Domain.Services
{
    public interface IEmployeeService
    {
        void Create(Employee employee);
        void Update(Employee employee);
        IEnumerable<Employee> GetAll();
        void Delete(int id);
    }
}
