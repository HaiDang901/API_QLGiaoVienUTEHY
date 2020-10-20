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
    public class Teacher_RanksOfficerController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_RanksOfficerController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_RanksOfficer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_RanksOfficer>>> GetTeacher_RanksOfficer()
        {
            return await _context.Teacher_RanksOfficer.ToListAsync();
        }

        // GET: api/Teacher_RanksOfficer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_RanksOfficer>> GetTeacher_RanksOfficer(int id)
        {
            var teacher_RanksOfficer = await _context.Teacher_RanksOfficer.FindAsync(id);

            if (teacher_RanksOfficer == null)
            {
                return NotFound();
            }

            return teacher_RanksOfficer;
        }

        // PUT: api/Teacher_RanksOfficer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_RanksOfficer(int id, Teacher_RanksOfficer teacher_RanksOfficer)
        {
            if (id != teacher_RanksOfficer.ID_Ranks)
            {
                return BadRequest();
            }

            _context.Entry(teacher_RanksOfficer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_RanksOfficerExists(id))
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

        // POST: api/Teacher_RanksOfficer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_RanksOfficer>> PostTeacher_RanksOfficer(Teacher_RanksOfficer teacher_RanksOfficer)
        {
            _context.Teacher_RanksOfficer.Add(teacher_RanksOfficer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_RanksOfficer", new { id = teacher_RanksOfficer.ID_Ranks }, teacher_RanksOfficer);
        }

        // DELETE: api/Teacher_RanksOfficer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_RanksOfficer>> DeleteTeacher_RanksOfficer(int id)
        {
            var teacher_RanksOfficer = await _context.Teacher_RanksOfficer.FindAsync(id);
            if (teacher_RanksOfficer == null)
            {
                return NotFound();
            }

            _context.Teacher_RanksOfficer.Remove(teacher_RanksOfficer);
            await _context.SaveChangesAsync();

            return teacher_RanksOfficer;
        }

        private bool Teacher_RanksOfficerExists(int id)
        {
            return _context.Teacher_RanksOfficer.Any(e => e.ID_Ranks == id);
        }
    }
}
