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
    public class Teacher_PositionController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_PositionController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Position
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Position>>> GetTeacher_Position()
        {
            return await _context.Teacher_Position.ToListAsync();
        }

        [HttpGet("position")]
        public async Task<ActionResult<IEnumerable<Teacher_Position>>> GetTeacher_Position1()
        {
            var teacher_Faculty = await _context.Teacher_Position
                .Include(pub => pub.Teachers)
                .ThenInclude(pub => pub.Teacher_Contract)
                .ToListAsync();

            if (teacher_Faculty == null)
            {
                return NotFound();
            }

            return teacher_Faculty;
        }
        // GET: api/Teacher_Position/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_Position>> GetTeacher_Position(int id)
        {
            var teacher_Position = await _context.Teacher_Position.FindAsync(id);

            if (teacher_Position == null)
            {
                return NotFound();
            }

            return teacher_Position;
        }

        // PUT: api/Teacher_Position/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Position(int id, Teacher_Position teacher_Position)
        {
            if (id != teacher_Position.ID_Position)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Position).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_PositionExists(id))
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

        // POST: api/Teacher_Position
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Position>> PostTeacher_Position(Teacher_Position teacher_Position)
        {
            _context.Teacher_Position.Add(teacher_Position);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Position", new { id = teacher_Position.ID_Position }, teacher_Position);
        }

        // DELETE: api/Teacher_Position/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Position>> DeleteTeacher_Position(int id)
        {
            var teacher_Position = await _context.Teacher_Position.FindAsync(id);
            if (teacher_Position == null)
            {
                return NotFound();
            }

            _context.Teacher_Position.Remove(teacher_Position);
            await _context.SaveChangesAsync();

            return teacher_Position;
        }

        private bool Teacher_PositionExists(int id)
        {
            return _context.Teacher_Position.Any(e => e.ID_Position == id);
        }
    }
}
