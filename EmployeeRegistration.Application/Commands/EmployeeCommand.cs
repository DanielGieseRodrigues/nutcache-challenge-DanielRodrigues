using EmployeeRegistratation.Domain.Enums;

namespace EmployeeRegistration.Application.Commands
{
    public class EmployeeCommand
    {
        //here would fit a CQRS, but I preferred to continue with KISS = KEEP IT SUPER SIMPLE
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string StartDate { get; set; }
        public ETeam Team { get; set; }
    }
}
