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
    public class TeachersController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public TeachersController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
        {
            return await _context.Teacher.ToListAsync();
        }


        // GET: api/Teachers/5
        [HttpGet("GetTeacherDetails/{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherDetails(string id)
        {
            var teacher = await _context.Teacher
                .Include(pub => pub.Teacher_Academic)
                .Include(pub => pub.Teacher_Contract)
                .Include(pub => pub.Teacher_SignUp)
                .Include(pub => pub.Teacher_Scientist)
                .Include(pub => pub.Teacher_DiscipRewards)
                .Where(pub => pub.ID_Teacher == id)
                .FirstOrDefaultAsync();
           // Explicit loading

            //var teacher = await _context.Teacher.SingleAsync(pub => pub.ID_Teacher == id);

            //_context.Entry(teacher)
            //    .Collection(pub => pub.Teacher_Academic)
            //    .Query()
            //    .Where(academic => academic.ID_Teacher.Contains("00000001"))
            //    .Load();

            //_context.Entry(teacher)
            //    .Collection(pub => pub.Teacher_Scientist)
            //    .Query()
            //    .Load();

            //var cademic = await _context.Teacher_Academic.SingleAsync(academic => academic.ID_Academic == 2);

            //_context.Entry(cademic)
            //    .Reference(academic => academic.ID_Teacher)
            //    .Load();

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // GET: api/Teachers/5
        [HttpGet("PostTeacherDetails/")]
        public async Task<ActionResult<Teacher>> PostTeacherDetails()
        {
            Teacher teachers = new Teacher();
            teachers.ID_Teacher = Convert.ToString(00000050);
            teachers.ID_Subject = 3;
            teachers.ID_Position = 3;
            teachers.ID_Ranks = 1;
            teachers.ID_Wage = 14;
            teachers.First_Name = "Nguyễn ";
            teachers.Last_Name = "Văn Long";
            teachers.Name_Teacher = "Nguyễn Văn Long";
            teachers.Gende_Teacher = false;
            teachers.Phone__Teacher = "0343584329";
            teachers.Email_Teacher = "longvn98@gmail.com";
            teachers.Address_Teacher = "Quất Lâm - Nam Định";
            teachers.Nation_Teacher = "Dân tộc Kinh";
            teachers.Religion_Teacher = "Phật Giáo";
            teachers.Level_Teacher = "Thạc sĩ";
            teachers.Experience_Teacher = "Hơn 7 năm kinh nghiệm trong nghề giáo";

                Teacher_Academic academic = new Teacher_Academic();
                academic.Name_Academic = "Thạc Sĩ ";
                academic.YearGredu_Academic = DateTime.Parse("2012/11/11");
                academic.Certificate_Academic = "ffsg";
                academic.Specialy__Academic = "ádfd";
                academic.UnitWork_Academic = "fafds";
                academic.LevelIT_Academic = "fsafds";
                academic.LevelLag_Academic = "fadfdsaf";
                academic.YeasTeaching_Academic = "gétrgr";
                academic.status = 1;

            teachers.Teacher_Academic.Add(academic);

            _context.Teacher.Add(teachers);
            _context.SaveChanges();



            var teacher = await _context.Teacher
                .Include(pub => pub.Teacher_Academic)
                .Include(pub => pub.Teacher_Contract)
                .Include(pub => pub.Teacher_SignUp)
                .Include(pub => pub.Teacher_Scientist)
                .Include(pub => pub.Teacher_DiscipRewards)
                .Where(pub => pub.ID_Teacher == teachers.ID_Teacher)
                .FirstOrDefaultAsync();

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }



        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(string id)
        {
            var teacher = await _context.Teacher.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        [HttpGet("getteach")]
        public async Task<ActionResult<Teacher>> GetTeacher1(string id)
        {
            var teacher =await _context.Teacher
                .Include(pub=>pub.Teacher_SignUp)
                .Include(pub=>pub.Teacher_Academic)
                .FirstOrDefaultAsync();

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(string id, Teacher teacher)
        {
            if (id != teacher.ID_Teacher)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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
        // POST: api/Teachers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeacherExists(teacher.ID_Teacher))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeacher", new { id = teacher.ID_Teacher }, teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(string id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }

        private bool TeacherExists(string id)
        {
            return _context.Teacher.Any(e => e.ID_Teacher == id);
        }
    }
}
