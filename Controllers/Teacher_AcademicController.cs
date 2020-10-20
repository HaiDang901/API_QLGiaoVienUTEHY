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
    public class Teacher_AcademicController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_AcademicController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Academic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Academic>>> GetTeacher_Academic()
        {
            return await _context.Teacher_Academic.ToListAsync();
        }

        // GET: api/Teacher_Academic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_Academic>> GetTeacher_Academic(int id)
        {
            var teacher_Academic = await _context.Teacher_Academic.FindAsync(id);

            if (teacher_Academic == null)
            {
                return NotFound();
            }

            return teacher_Academic;
        }

        // PUT: api/Teacher_Academic/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Academic(int id, Teacher_Academic teacher_Academic)
        {
            if (id != teacher_Academic.ID_Academic)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Academic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_AcademicExists(id))
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

        // POST: api/Teacher_Academic
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Academic>> PostTeacher_Academic(Teacher_Academic teacher_Academic)
        {
            _context.Teacher_Academic.Add(teacher_Academic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Academic", new { id = teacher_Academic.ID_Academic }, teacher_Academic);
        }

        // DELETE: api/Teacher_Academic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Academic>> DeleteTeacher_Academic(int id)
        {
            var teacher_Academic = await _context.Teacher_Academic.FindAsync(id);
            if (teacher_Academic == null)
            {
                return NotFound();
            }

            _context.Teacher_Academic.Remove(teacher_Academic);
            await _context.SaveChangesAsync();

            return teacher_Academic;
        }

        private bool Teacher_AcademicExists(int id)
        {
            return _context.Teacher_Academic.Any(e => e.ID_Academic == id);
        }
    }
}
