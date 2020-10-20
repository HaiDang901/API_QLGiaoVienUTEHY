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
    public class Teacher_ScientistController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_ScientistController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Scientist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Scientist>>> GetTeacher_Scientist()
        {
            return await _context.Teacher_Scientist.ToListAsync();
        }

        // GET: api/Teacher_Scientist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_Scientist>> GetTeacher_Scientist(int id)
        {
            var teacher_Scientist = await _context.Teacher_Scientist.FindAsync(id);

            if (teacher_Scientist == null)
            {
                return NotFound();
            }

            return teacher_Scientist;
        }

        // PUT: api/Teacher_Scientist/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Scientist(int id, Teacher_Scientist teacher_Scientist)
        {
            if (id != teacher_Scientist.ID_Scientist)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Scientist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_ScientistExists(id))
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

        // POST: api/Teacher_Scientist
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Scientist>> PostTeacher_Scientist(Teacher_Scientist teacher_Scientist)
        {
            _context.Teacher_Scientist.Add(teacher_Scientist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Scientist", new { id = teacher_Scientist.ID_Scientist }, teacher_Scientist);
        }

        // DELETE: api/Teacher_Scientist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Scientist>> DeleteTeacher_Scientist(int id)
        {
            var teacher_Scientist = await _context.Teacher_Scientist.FindAsync(id);
            if (teacher_Scientist == null)
            {
                return NotFound();
            }

            _context.Teacher_Scientist.Remove(teacher_Scientist);
            await _context.SaveChangesAsync();

            return teacher_Scientist;
        }

        private bool Teacher_ScientistExists(int id)
        {
            return _context.Teacher_Scientist.Any(e => e.ID_Scientist == id);
        }
    }
}
