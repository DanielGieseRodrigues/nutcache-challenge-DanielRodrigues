using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EmployeeRegistrationGui.Core
{
    public class Employee
    {
        public Employee()
        {

        }
        public Employee(string name, DateTime birthDate, EGender gender, string email, string cPF, string startDate, ETeam? team)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            CPF = cPF;
            StartDate = startDate;
            Team = team;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Description = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        [Display(Description ="Start Date", Name =" Start Date")]
        public string StartDate { get; set; }
        public ETeam? Team { get; set; }
    }
    public enum EGender
    {
        Male,
        Female,
        Other
    }
    public enum ETeam
    {
        Unassigned,
        Mobile,
        FrontEnd,
        BackEnd
    }
}