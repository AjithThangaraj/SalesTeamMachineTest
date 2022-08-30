using Microsoft.AspNetCore.Mvc;
using SalesTeamMachineTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesTeamMachineTest.Repository
{
    public interface ILoginRepository
    {
        public Task<ActionResult<IEnumerable<Login>>> GetLogin();

        public Task<int> PostTblEmployees(Login login);
    }
}
