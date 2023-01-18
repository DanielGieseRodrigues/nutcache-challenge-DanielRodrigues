using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistrationGui.Core
{
    public class EmployeeCommand
    {

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string StartDate { get; set; }
        public ETeam Team { get; set; }
    }
}
