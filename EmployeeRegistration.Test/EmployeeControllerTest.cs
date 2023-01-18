using EmployeeRegistratation.Api.DTOs;
using EmployeeRegistratation.Controllers;
using EmployeeRegistratation.Domain.Enums;
using EmployeeRegistration.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EmployeeRegistration.Test
{
    public class EmployeeControllerTest
    {
        EmployeeController _employeeController = new EmployeeController(new EmployeeServiceFaker());

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _employeeController.Get();
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var okResult = _employeeController.Get() as OkObjectResult;

            var items = Assert.IsType<List<EmployeeDto>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var wrongEmployeeCommand = new EmployeeCommand()
            {
                Name = "Wrong input",
                CPF = "01z1a01"
            };
            _employeeController.ModelState.AddModelError("Name", "Required");

            var badResponse = _employeeController.Post(wrongEmployeeCommand);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsOk()
        {
            EmployeeCommand employeeTest = new EmployeeCommand()
            { Name = "Colin", BirthDate = new DateTime(1995, 2, 2), CPF = "02826467321", Email = "test72@gmail.com", Gender = EGender.Male, StartDate = "02/1998", Team = ETeam.Mobile };

            var createdResponse = _employeeController.Post(employeeTest);

            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            EmployeeCommand employeeTest = new EmployeeCommand()
            { Name = "Max", BirthDate = new DateTime(1991, 1, 3), CPF = "12345678910", Email = "testmail@gmail.com", Gender = EGender.Male, StartDate = "02/1991", Team = ETeam.Mobile };

            var createdResponse = _employeeController.Post(employeeTest) as OkObjectResult;
            var item = createdResponse.Value as EmployeeCommand;

            Assert.IsType<EmployeeCommand>(item);
            Assert.Equal("Max", item.Name);
        }

        [Fact]
        public void Remove_ReturnsOk()
        {
            var noContentResponse = _employeeController.Delete(1);
            Assert.IsType<OkResult>(noContentResponse);
        }
    }
}