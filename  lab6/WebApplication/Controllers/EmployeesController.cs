using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TouristAgencyContext _db;

        public EmployeesController(TouristAgencyContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await _db.Employees.Include(e => e.Position).Take(20).ToListAsync();
        }

        [HttpGet("positions")]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
            return await _db.Positions.OrderBy(g => g.Id).ToListAsync();
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            Employee employee = await _db.Employees.Include(e => e.Position).FirstOrDefaultAsync(s => s.Id == id);
            if (employee == null)
                return NotFound();

            return new ObjectResult(employee);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            if (employee == null)
                return BadRequest();

            var position = await _db.Positions.FirstOrDefaultAsync(p => p.Id == employee.PositionId);
            if (position == null)
                return NotFound();

            Employee show = new Employee
            {
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                BirthDate = employee.BirthDate,
                PositionId = position.Id
            };

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();

            employee.Id = _db.Employees.ToList().LastOrDefault().Id;
            employee.Position = position;
            return Ok(employee);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            Employee oldEmployee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (oldEmployee == null)
                return NotFound();

            oldEmployee.Id = employee.Id;
            oldEmployee.LastName = employee.LastName;
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.MiddleName = employee.MiddleName;
            oldEmployee.BirthDate = employee.BirthDate;
            oldEmployee.PositionId = employee.PositionId;

            _db.Update(oldEmployee);
            await _db.SaveChangesAsync();

            employee.Position = _db.Positions.FirstOrDefault(p => p.Id == employee.PositionId);
            return Ok(employee);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            Employee employee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
