using Domain.Exceptions;
using EmployeeRegistratation.Domain.Enums;
using System;

namespace EmployeeRegistratation.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
        }

        public Employee(string name, DateTime birthDate, EGender gender, string email, string cpf, string startDate, ETeam team, int id = 0)
        {
            EmployeeValidate(name,birthDate,email,cpf,startDate,gender);
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            CPF = cpf;
            StartDate = startDate;
            Team = team;
            if (id != 0)
                Id = id;
        }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string StartDate { get; set; }
        public ETeam? Team { get; set; }

        private void EmployeeValidate(string name, DateTime birthDate, string email, string cpf, string startDate, EGender gender)
        {
            List<string> errors = new List<string>();

            //Fluent validator would be the ideal here.
            if (name.Length < 3)
                errors.Add(" Name lenght too short, please check the input value and try again");

            if (!Enum.IsDefined(typeof(EGender), gender))
                errors.Add(" Incorrect gender value, please check the input value and try again");

            if (email.Length < 5)
                errors.Add(" Email lenght too short, please check the input value and try again");

            if (cpf.Length != 11)
                errors.Add(" CPF lenght is wrong, please check the input value and try again");

            if (birthDate < new DateTime(1901, 1, 1))
                errors.Add(" Employee cant be that old!");
            
            //a regex with fluent validator would be perfect for this one.
            if (!startDate.Contains('/'))
                errors.Add(" Wrong format at start date!");

            if (errors.Count > 0)
                throw new ValidationException(errors);

        }
    }

}
