using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesTeamMachineTest.Models
{
    public partial class Login
    {
        public Login()
        {
            EmployeeRegistration = new HashSet<EmployeeRegistration>();
        }

        public int LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<EmployeeRegistration> EmployeeRegistration { get; set; }
    }
}
