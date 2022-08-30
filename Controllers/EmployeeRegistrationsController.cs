using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTeamMachineTest.Models;

namespace SalesTeamMachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRegistrationsController : ControllerBase
    {
        private readonly salesTeamContext _context;

        public EmployeeRegistrationsController(salesTeamContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeRegistration>>> GetEmployeeRegistration()
        {
            return await _context.EmployeeRegistration.ToListAsync();
        }

        // GET: api/EmployeeRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeRegistration>> GetEmployeeRegistration(int id)
        {
            var employeeRegistration = await _context.EmployeeRegistration.FindAsync(id);

            if (employeeRegistration == null)
            {
                return NotFound();
            }

            return employeeRegistration;
        }

        // PUT: api/EmployeeRegistrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeRegistration(int id, EmployeeRegistration employeeRegistration)
        {
            if (id != employeeRegistration.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employeeRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeRegistrationExists(id))
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

        // POST: api/EmployeeRegistrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeRegistration>> PostEmployeeRegistration(EmployeeRegistration employeeRegistration)
        {
            _context.EmployeeRegistration.Add(employeeRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeRegistration", new { id = employeeRegistration.EmpId }, employeeRegistration);
        }

        // DELETE: api/EmployeeRegistrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeRegistration>> DeleteEmployeeRegistration(int id)
        {
            var employeeRegistration = await _context.EmployeeRegistration.FindAsync(id);
            if (employeeRegistration == null)
            {
                return NotFound();
            }

            _context.EmployeeRegistration.Remove(employeeRegistration);
            await _context.SaveChangesAsync();

            return employeeRegistration;
        }

        private bool EmployeeRegistrationExists(int id)
        {
            return _context.EmployeeRegistration.Any(e => e.EmpId == id);
        }
    }
}
