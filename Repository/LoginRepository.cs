using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTeamMachineTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesTeamMachineTest.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly salesTeamContext _context;


        //Constructor Injection
        public LoginRepository(salesTeamContext context)
        {
            _context = context;
        }



        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            if (_context != null)
            {
                return await _context.Login.ToListAsync();
            }
            return null;
        }


        public async Task<int> PostLogin(Login login)
        {
            if (_context != null)
            {
                await _context.Login.AddAsync(login);
                await _context.SaveChangesAsync();

                return login.LId;
            }
            return 0;
        }

    }
}
