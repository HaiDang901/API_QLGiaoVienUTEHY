using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB_DoAn5.Models;

namespace DB_DoAn5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher_SalaryController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_SalaryController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Salary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Salary>>> GetTeacher_Salary()
        {
            return await _context.Teacher_Salary.ToListAsync();
        }

        // GET: api/Teacher_Salary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_Salary>> GetTeacher_Salary(int id)
        {
            var teacher_Salary = await _context.Teacher_Salary.FindAsync(id);

            if (teacher_Salary == null)
            {
                return NotFound();
            }

            return teacher_Salary;
        }

        // PUT: api/Teacher_Salary/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Salary(int id, Teacher_Salary teacher_Salary)
        {
            if (id != teacher_Salary.ID_Salary)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Salary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_SalaryExists(id))
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

        // POST: api/Teacher_Salary
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Salary>> PostTeacher_Salary(Teacher_Salary teacher_Salary)
        {
            _context.Teacher_Salary.Add(teacher_Salary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Salary", new { id = teacher_Salary.ID_Salary }, teacher_Salary);
        }

        // DELETE: api/Teacher_Salary/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Salary>> DeleteTeacher_Salary(int id)
        {
            var teacher_Salary = await _context.Teacher_Salary.FindAsync(id);
            if (teacher_Salary == null)
            {
                return NotFound();
            }

            _context.Teacher_Salary.Remove(teacher_Salary);
            await _context.SaveChangesAsync();

            return teacher_Salary;
        }

        private bool Teacher_SalaryExists(int id)
        {
            return _context.Teacher_Salary.Any(e => e.ID_Salary == id);
        }
    }
}
