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
    public class Teacher_WageController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_WageController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Wage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Wage>>> GetTeacher_Wage()
        {
            return await _context.Teacher_Wage.ToListAsync();
        }

        // GET: api/Teacher_Wage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_Wage>> GetTeacher_Wage(int id)
        {
            var teacher_Wage = await _context.Teacher_Wage.FindAsync(id);

            if (teacher_Wage == null)
            {
                return NotFound();
            }

            return teacher_Wage;
        }

        // PUT: api/Teacher_Wage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Wage(int id, Teacher_Wage teacher_Wage)
        {
            if (id != teacher_Wage.ID_Wage)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Wage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_WageExists(id))
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

        // POST: api/Teacher_Wage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Wage>> PostTeacher_Wage(Teacher_Wage teacher_Wage)
        {
            _context.Teacher_Wage.Add(teacher_Wage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Wage", new { id = teacher_Wage.ID_Wage }, teacher_Wage);
        }

        // DELETE: api/Teacher_Wage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Wage>> DeleteTeacher_Wage(int id)
        {
            var teacher_Wage = await _context.Teacher_Wage.FindAsync(id);
            if (teacher_Wage == null)
            {
                return NotFound();
            }

            _context.Teacher_Wage.Remove(teacher_Wage);
            await _context.SaveChangesAsync();

            return teacher_Wage;
        }

        private bool Teacher_WageExists(int id)
        {
            return _context.Teacher_Wage.Any(e => e.ID_Wage == id);
        }
    }
}
