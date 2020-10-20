using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DB_DoAn5.Models;
using System.Security.Cryptography.X509Certificates;

namespace DB_DoAn5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Teacher_SubjectController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_SubjectController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Subject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Subject>>> GetTeacher_Subject()
        {
            return await _context.Teacher_Subject.ToListAsync();
        }


        // GET: api/Teacher_Subject/5
        [HttpGet("GetSubjectDetails/{id}")]
        public async Task<ActionResult<Teacher_Subject>> GetSubjectDetails(int id)
        {
            var teacher_Subject = await _context.Teacher_Subject
                .Include(pub => pub.Teachers)
                .ThenInclude(teacher => teacher.Teacher_Academic)
                .Where(pub => pub.ID_Subject == id)
                .FirstOrDefaultAsync();

            if (teacher_Subject == null)
            {
                return NotFound();
            }

            return teacher_Subject;
        }

        // GET: api/Teacher_Subject/5
        [HttpGet("PostSubjectDetails/")]
        public async Task<ActionResult<Teacher_Subject>> PostSubjectDetails( )
        {
            var subject = new Teacher_Subject();
            subject.ID_Faculty = 5;
            subject.Name_Subject = "Khoa Điện Tử Viễn Thông ";
            subject.Address_Subject = "Cơ sở 1 Dân Tiến KHoái Châu Hưng Yên";
            subject.Phone_Subject = "0347359986";
            subject.Leader = " Nguyễn Văn Đức";
            subject.Leader_Assis = "Đỗ Tuấn Anh ";

                Teacher teacher = new Teacher();
                teacher.ID_Teacher = Convert.ToString(00000045);
                teacher.ID_Subject = 3;
                teacher.ID_Position = 3;
                teacher.ID_Ranks = 1;
                teacher.ID_Wage = 14;
                teacher.First_Name = "Nguyễn ";
                teacher.Last_Name = "Tiến Đạt";
                teacher.Name_Teacher = "Nguyễn Tiến Đạt";
                teacher.Gende_Teacher = false;
                teacher.Phone__Teacher = "0343584329";
                teacher.Email_Teacher = "nambv98@gmail.com";
                teacher.Address_Teacher = "Đào Văn- Tiên Lữ- Hưng Yên";
                teacher.Nation_Teacher = "Dân tộc Kinh";
                teacher.Religion_Teacher = "Phật Giáo";
                teacher.Level_Teacher = "Thạc sĩ";
                teacher.Experience_Teacher = "Hơn 7 năm kinh nghiệm trong nghề giáo";

            //        Teacher_Academic academic = new Teacher_Academic();
            //        academic.Name_Academic = "Thạc Sĩ ";
            //        academic.YearGredu_Academic = DateTime.Parse("2004/11/11");
            //        academic.Certificate_Academic = "ffsg";
            //        academic.Specialy__Academic = "ádfd";
            //        academic.UnitWork_Academic = "fafds";
            //        academic.LevelIT_Academic = "fsafds";
            //        academic.LevelLag_Academic = "fadfdsaf";
            //        academic.YeasTeaching_Academic = "gétrgr";
            //        academic.status = 1;

            //teacher.Teacher_Academic.Add(academic);
            subject.Teachers.Add(teacher);
            
                    
            _context.Teacher_Subject.Add(subject);
            _context.SaveChanges();



            var teacher_Subject = await _context.Teacher_Subject
                .Include(pub => pub.Teachers)
                .ThenInclude(teacher => teacher.Teacher_Academic)
                .Where(pub => pub.ID_Subject == subject.ID_Subject)
                .FirstOrDefaultAsync();

            if (teacher_Subject == null)
            {
                return NotFound();
            }

            return teacher_Subject;
        }
        // PUT: api/Teacher_Subject/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Subject(int id, Teacher_Subject teacher_Subject)
        {
            if (id != teacher_Subject.ID_Subject)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_SubjectExists(id))
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

        // POST: api/Teacher_Subject
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Subject>> PostTeacher_Subject(Teacher_Subject teacher_Subject)
        {
            _context.Teacher_Subject.Add(teacher_Subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Subject", new { id = teacher_Subject.ID_Subject }, teacher_Subject);
        }

        // DELETE: api/Teacher_Subject/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Subject>> DeleteTeacher_Subject(int id)
        {
            var teacher_Subject = await _context.Teacher_Subject.FindAsync(id);
            if (teacher_Subject == null)
            {
                return NotFound();
            }

            _context.Teacher_Subject.Remove(teacher_Subject);
            await _context.SaveChangesAsync();

            return teacher_Subject;
        }

        private bool Teacher_SubjectExists(int id)
        {
            return _context.Teacher_Subject.Any(e => e.ID_Subject == id);
        }
    }
}
