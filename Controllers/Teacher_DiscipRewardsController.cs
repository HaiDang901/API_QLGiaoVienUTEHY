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
    public class Teacher_DiscipRewardsController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_DiscipRewardsController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_DiscipRewards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_DiscipRewards>>> GetTeacher_DiscipRewards()
        {
            return await _context.Teacher_DiscipRewards.ToListAsync();
        }

        // GET: api/Teacher_DiscipRewards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher_DiscipRewards>> GetTeacher_DiscipRewards(int id)
        {
            var teacher_DiscipRewards = await _context.Teacher_DiscipRewards.FindAsync(id);

            if (teacher_DiscipRewards == null)
            {
                return NotFound();
            }

            return teacher_DiscipRewards;
        }

        // PUT: api/Teacher_DiscipRewards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_DiscipRewards(int id, Teacher_DiscipRewards teacher_DiscipRewards)
        {
            if (id != teacher_DiscipRewards.ID_DisRewards)
            {
                return BadRequest();
            }

            _context.Entry(teacher_DiscipRewards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_DiscipRewardsExists(id))
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

        // POST: api/Teacher_DiscipRewards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_DiscipRewards>> PostTeacher_DiscipRewards(Teacher_DiscipRewards teacher_DiscipRewards)
        {
            _context.Teacher_DiscipRewards.Add(teacher_DiscipRewards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_DiscipRewards", new { id = teacher_DiscipRewards.ID_DisRewards }, teacher_DiscipRewards);
        }

        // DELETE: api/Teacher_DiscipRewards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_DiscipRewards>> DeleteTeacher_DiscipRewards(int id)
        {
            var teacher_DiscipRewards = await _context.Teacher_DiscipRewards.FindAsync(id);
            if (teacher_DiscipRewards == null)
            {
                return NotFound();
            }

            _context.Teacher_DiscipRewards.Remove(teacher_DiscipRewards);
            await _context.SaveChangesAsync();

            return teacher_DiscipRewards;
        }

        private bool Teacher_DiscipRewardsExists(int id)
        {
            return _context.Teacher_DiscipRewards.Any(e => e.ID_DisRewards == id);
        }
    }
}
