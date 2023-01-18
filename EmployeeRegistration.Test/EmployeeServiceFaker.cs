using EmployeeRegistratation.Domain.Entities;
using EmployeeRegistratation.Domain.Enums;
using EmployeeRegistratation.Domain.Services;

namespace EmployeeRegistration.Test
{
    public class EmployeeServiceFaker : IEmployeeService
    {
        public EmployeeServiceFaker()
        {
            _employees = new List<Employee>()
            {
                new Employee() { Id = 1,Name = "Chris", BirthDate = new DateTime(1992,2,2), CPF = "08826467321",Email = "test@gmail.com",Gender = EGender.Male,StartDate = "02/1999",Team = ETeam.Mobile },
                new Employee() { Id = 2,Name = "Jhon", BirthDate = new DateTime(1951,2,2), CPF = "08826467322",Email = "test2@gmail.com",Gender = EGender.Male,StartDate = "01/2001",Team = ETeam.BackEnd },
                new Employee() { Id = 3,Name = "Alfred", BirthDate = new DateTime(1965,2,2), CPF = "08826467323",Email = "test3@gmail.com",Gender = EGender.Male,StartDate = "04/2009",Team = ETeam.FrontEnd }
            };
        }
        public List<Employee> _employees { get; set; } = new List<Employee>();
        public void Create(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(int id)
        {
            var item = _employees.First(p => p.Id == id);
            _employees.Remove(item);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public void Update(Employee employee)
        {
            _employees[_employees.FindIndex(p => p.Id == employee.Id)] = employee;
        }
    }
}
