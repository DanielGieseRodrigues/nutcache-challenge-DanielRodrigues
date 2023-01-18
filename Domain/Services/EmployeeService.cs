using ConEmployeeRegistratationtatos.Domain.Interfaces;
using EmployeeRegistratation.Domain.Entities;
using EmployeeRegistratation.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmployeeRegistratation.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IRepository<Employee> employeeRepository, IUnitOfWork unitOfWork, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void Create(Employee employee)
        {
            try
            {
                _employeeRepository.Save(employee);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        public void Update(Employee employee)
        {
            try
            {
                _employeeRepository.Update(employee);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public void Delete(int id)
        {
            try
            {
                Employee employee = _employeeRepository.GetById(id);
                _employeeRepository.Delete(employee);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

    }
}
