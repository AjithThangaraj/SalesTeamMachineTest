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
    public class VisitTablesController : ControllerBase
    {
        private readonly IVisitTableRepository _repository;

        public VisitTablesController(IVisitTableRepository repository)
        {
            _repository = repository;
        }

        // GET: api/VisitTables

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Repository.VisitTable>>> GetVisitTable()
        {
            return await _repository.GetVisitTable();
            
        }

        
        [HttpPut]
        public async Task<IActionResult> PutVisitTable(VisitTable visitTable)
        {


            if (ModelState.IsValid)
            {
                var visit = await _repository.PutVisitTable(visitTable);

                if (visit != null)
                {
                    return Ok(CustName);
                }
                else
                {
                    return NotFound();

                }

            }
            return BadRequest();
        }
        
        [HttpPost]
        public async Task<ActionResult> PostVisitTable([FromBody] VisitTable visitTable)
        {
            if (ModelState.IsValid)
            {
                var newEmployeeId = await _repository.PostVisitTable(visitTable);

                if (newEmployeeId > 0)
                {
                    return Ok(newEmployeeId);
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
            
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> PostTblEmployeesReturnRecord([FromBody] TblEmployees tblEmployees)
        {
            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named employee
                var newEmployeeId = await _repository.PostTblEmployeesReturnRecord(tblEmployees);

                if (newEmployeeId != null)
                {
                    return Ok(newEmployeeId);
                }
                else
                {
                    return NotFound();
                }

            }
            

            return BadRequest();
            
        }


        // DELETE: api/TblEmployees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEmployees>> DeleteTblEmployees(int id)
        {
            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named employee
                var newEmployeeId = await _repository.DeleteTblEmployees(id);

                if (newEmployeeId != null)
                {
                    return Ok(newEmployeeId);
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
