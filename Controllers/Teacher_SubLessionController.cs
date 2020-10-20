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
    public class Teacher_SubLessionController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_SubLessionController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_SubLession
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_SubLession>>> GetTeacher_SubLession()
        {
            return await _context.Teacher_SubLession.ToListAsync();
        }

        // GET: api/Teacher_SubLession/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_SubLession>> GetTeacher_SubLession(int id)
        {
            var teacher_SubLession = await _context.Teacher_SubLession.FindAsync(id);

            if (teacher_SubLession == null)
            {
                return NotFound();
            }

            return teacher_SubLession;
        }

        // PUT: api/Teacher_SubLession/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_SubLession(int id, Teacher_SubLession teacher_SubLession)
        {
            if (id != teacher_SubLession.ID_Sub)
            {
                return BadRequest();
            }

            _context.Entry(teacher_SubLession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_SubLessionExists(id))
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

        // POST: api/Teacher_SubLession
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_SubLession>> PostTeacher_SubLession(Teacher_SubLession teacher_SubLession)
        {
            _context.Teacher_SubLession.Add(teacher_SubLession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_SubLession", new { id = teacher_SubLession.ID_Sub }, teacher_SubLession);
        }

        // DELETE: api/Teacher_SubLession/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_SubLession>> DeleteTeacher_SubLession(int id)
        {
            var teacher_SubLession = await _context.Teacher_SubLession.FindAsync(id);
            if (teacher_SubLession == null)
            {
                return NotFound();
            }

            _context.Teacher_SubLession.Remove(teacher_SubLession);
            await _context.SaveChangesAsync();

            return teacher_SubLession;
        }

        private bool Teacher_SubLessionExists(int id)
        {
            return _context.Teacher_SubLession.Any(e => e.ID_Sub == id);
        }
    }
}
