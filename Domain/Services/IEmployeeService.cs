using EmployeeRegistratation.Domain.Entities;

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
