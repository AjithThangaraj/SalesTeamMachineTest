using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTeamMachineTest.Models;
using SalesTeamMachineTest.Repository;

namespace SalesTeamMachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginRepository _repository;

        public LoginsController(ILoginRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            return await _repository.GetLogin();
        }

        // GET: api/Logins/5
       

        // PUT: api/Logins/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.LId)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public async Task<ActionResult> PostLogin([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                var newlogin = await _repository.PostLogin(login);

                if (newlogin > 0)
                {
                    return Ok(newlogin);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
            
        }

        
    }
}
