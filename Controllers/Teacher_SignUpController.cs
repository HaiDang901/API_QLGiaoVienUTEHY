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
    public class Teacher_SignUpController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_SignUpController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_SignUp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_SignUp>>> GetTeacher_SignUp()
        {
            return await _context.Teacher_SignUp.ToListAsync();
        }

        // GET: api/Teacher_SignUp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_SignUp>> GetTeacher_SignUp(int id)
        {
            var teacher_SignUp = await _context.Teacher_SignUp.FindAsync(id);

            if (teacher_SignUp == null)
            {
                return NotFound();
            }

            return teacher_SignUp;
        }

        // PUT: api/Teacher_SignUp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_SignUp(int id, Teacher_SignUp teacher_SignUp)
        {
            if (id != teacher_SignUp.ID_SignUp)
            {
                return BadRequest();
            }

            _context.Entry(teacher_SignUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_SignUpExists(id))
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

        // POST: api/Teacher_SignUp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_SignUp>> PostTeacher_SignUp(Teacher_SignUp teacher_SignUp)
        {
            _context.Teacher_SignUp.Add(teacher_SignUp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_SignUp", new { id = teacher_SignUp.ID_SignUp }, teacher_SignUp);
        }

        // DELETE: api/Teacher_SignUp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_SignUp>> DeleteTeacher_SignUp(int id)
        {
            var teacher_SignUp = await _context.Teacher_SignUp.FindAsync(id);
            if (teacher_SignUp == null)
            {
                return NotFound();
            }

            _context.Teacher_SignUp.Remove(teacher_SignUp);
            await _context.SaveChangesAsync();

            return teacher_SignUp;
        }

        private bool Teacher_SignUpExists(int id)
        {
            return _context.Teacher_SignUp.Any(e => e.ID_SignUp == id);
        }
    }
}
