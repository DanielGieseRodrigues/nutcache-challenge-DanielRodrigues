using EmployeeRegistratation.Api.DTOs;
using EmployeeRegistratation.Domain.Entities;
using EmployeeRegistratation.Domain.Services;
using EmployeeRegistration.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistratation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public IActionResult Get()
        {
            var result = _employeeService.GetAll().Select(e => new EmployeeDto { Id = e.Id, Name = e.Name, BirthDate = e.BirthDate, Gender = e.Gender, Email = e.Email, CPF = e.CPF, StartDate = e.StartDate, Team = e.Team }).ToList();
            return Ok(result);
        }

        [HttpPost(Name = "CreateEmployees")]
        public IActionResult Post(EmployeeCommand employeeCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Employee employee = new Employee(employeeCommand.Name, employeeCommand.BirthDate, employeeCommand.Gender, employeeCommand.Email, employeeCommand.CPF, employeeCommand.StartDate, employeeCommand.Team);
            _employeeService.Create(employee);
            return Ok(employeeCommand);
        }

        [HttpPut(Name = "UpdateEmployees")]
        public IActionResult Put(int employeeId, EmployeeCommand employeeCommand)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Employee employee = new Employee(employeeCommand.Name, employeeCommand.BirthDate, employeeCommand.Gender, employeeCommand.Email, employeeCommand.CPF, employeeCommand.StartDate, employeeCommand.Team, employeeId);
            _employeeService.Update(employee);
            return Ok();
        }

        [HttpDelete(Name = "RemoveEmployees")]
        public IActionResult Delete(int employeeId)
        {
            _employeeService.Delete(employeeId);
            return Ok();
        }
    }
}