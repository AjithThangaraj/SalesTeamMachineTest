using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SalesTeamMachineTest.Models
{
    public partial class EmployeeRegistration
    {
        public EmployeeRegistration()
        {
            VisitTable = new HashSet<VisitTable>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<VisitTable> VisitTable { get; set; }
    }
}
