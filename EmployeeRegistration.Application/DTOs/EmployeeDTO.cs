using EmployeeRegistratation.Domain.Enums;

namespace EmployeeRegistratation.Api.DTOs
{
    public class EmployeeDto
    {
        //Maybe a automapper, but for performance reasons, I preferred to go with the dto.
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string StartDate { get; set; }
        public ETeam? Team { get; set; }
    }
}
