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
    public class Teacher_SalaryRaiseController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_SalaryRaiseController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_SalaryRaise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_SalaryRaise>>> GetTeacher_SalaryRaise()
        {
            return await _context.Teacher_SalaryRaise.ToListAsync();
        }

        // GET: api/Teacher_SalaryRaise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_SalaryRaise>> GetTeacher_SalaryRaise(int id)
        {
            var teacher_SalaryRaise = await _context.Teacher_SalaryRaise.FindAsync(id);

            if (teacher_SalaryRaise == null)
            {
                return NotFound();
            }

            return teacher_SalaryRaise;
        }

        // PUT: api/Teacher_SalaryRaise/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_SalaryRaise(int id, Teacher_SalaryRaise teacher_SalaryRaise)
        {
            if (id != teacher_SalaryRaise.ID_Raise)
            {
                return BadRequest();
            }

            _context.Entry(teacher_SalaryRaise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_SalaryRaiseExists(id))
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

        // POST: api/Teacher_SalaryRaise
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_SalaryRaise>> PostTeacher_SalaryRaise(Teacher_SalaryRaise teacher_SalaryRaise)
        {
            _context.Teacher_SalaryRaise.Add(teacher_SalaryRaise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_SalaryRaise", new { id = teacher_SalaryRaise.ID_Raise }, teacher_SalaryRaise);
        }

        // DELETE: api/Teacher_SalaryRaise/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_SalaryRaise>> DeleteTeacher_SalaryRaise(int id)
        {
            var teacher_SalaryRaise = await _context.Teacher_SalaryRaise.FindAsync(id);
            if (teacher_SalaryRaise == null)
            {
                return NotFound();
            }

            _context.Teacher_SalaryRaise.Remove(teacher_SalaryRaise);
            await _context.SaveChangesAsync();

            return teacher_SalaryRaise;
        }

        private bool Teacher_SalaryRaiseExists(int id)
        {
            return _context.Teacher_SalaryRaise.Any(e => e.ID_Raise == id);
        }
    }
}
