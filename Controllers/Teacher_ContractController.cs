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
    public class Teacher_ContractController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_ContractController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Contract
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Contract>>> GetTeacher_Contract()
        {
            return await _context.Teacher_Contract.ToListAsync();
        }

        // GET: api/Teacher_Contract/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_Contract>> GetTeacher_Contract(int id)
        {
            var teacher_Contract = await _context.Teacher_Contract.FindAsync(id);

            if (teacher_Contract == null)
            {
                return NotFound();
            }

            return teacher_Contract;
        }

        // PUT: api/Teacher_Contract/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Contract(int id, Teacher_Contract teacher_Contract)
        {
            if (id != teacher_Contract.ID_Contract)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Contract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_ContractExists(id))
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

        // POST: api/Teacher_Contract
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Contract>> PostTeacher_Contract(Teacher_Contract teacher_Contract)
        {
            _context.Teacher_Contract.Add(teacher_Contract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Contract", new { id = teacher_Contract.ID_Contract }, teacher_Contract);
        }

        // DELETE: api/Teacher_Contract/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Contract>> DeleteTeacher_Contract(int id)
        {
            var teacher_Contract = await _context.Teacher_Contract.FindAsync(id);
            if (teacher_Contract == null)
            {
                return NotFound();
            }

            _context.Teacher_Contract.Remove(teacher_Contract);
            await _context.SaveChangesAsync();

            return teacher_Contract;
        }

        private bool Teacher_ContractExists(int id)
        {
            return _context.Teacher_Contract.Any(e => e.ID_Contract == id);
        }
    }
}
