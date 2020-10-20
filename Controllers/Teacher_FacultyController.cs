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
    public class Teacher_FacultyController : ControllerBase
    {
        private readonly DB_DoAn5Context _context;

        public Teacher_FacultyController(DB_DoAn5Context context)
        {
            _context = context;
        }

        // GET: api/Teacher_Faculty
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher_Faculty>>> GetTeacher_Faculty()
        {
            return await _context.Teacher_Faculty.ToListAsync();
        }

        // GET: api/Teacher_Faculty/5
        [HttpGet("GetFacultyDetails/{id}")]
        public async Task<ActionResult<Teacher_Faculty>> GetFacultyDetails(int id)
        {
            var teacher_Faculty = await _context.Teacher_Faculty
                .Include(pub => pub.Teacher_Subject)
                .ThenInclude(subject => subject.Teachers)
                .Include(pub => pub.Teacher_Position)
                .ThenInclude(positon => positon.Teachers)
                .Where(pub => pub.ID_Faculty == id)
                .FirstOrDefaultAsync();


            // Explicit loading

            //var teacher_Faculty = await _context.Teacher_Faculty.SingleAsync(pub => pub.ID_Faculty == id);

            //_context.Entry(teacher_Faculty)
            //    .Collection(pub => pub.Teacher_Subject)
            //    .Query()
            //    .Where(sub => sub.Name_Subject.Contains("Công nghệ phần mềm"))
            //    .Load();

            //_context.Entry(teacher_Faculty)
            //    .Collection(pub => pub.Teacher_Position)
            //    .Query()
            //    .Include(pos => pos.Teachers)
            //    .Load();

            //var subject = await _context.Teacher_Subject.SingleAsync(sub => sub.ID_Subject == 1);

            //_context.Entry(subject)
            //    .Reference(sub => sub.Name_Subject)
            //    .Load();

            if (teacher_Faculty == null)
            {
                return NotFound();
            }

            return teacher_Faculty;
        }

        // GET: api/Teacher_Faculty/5
        [HttpGet("PostFacultyDetails/")]
        public async Task<ActionResult<Teacher_Faculty>> PostFacultyDetails( )
        {
            var faculty = new Teacher_Faculty();
            faculty.Name_Faculty = "Khoa Tự Động Hóa";
            faculty.Address_Faculty = " Cơ sở 1 Dân Tiến Khoái Châu";
            faculty.Learder_Faculty = "Nguyễn Tất Thành";
            faculty.Website_Facuty = "http://www.utehy.edu.vn/#/";

            Teacher_Position position = new Teacher_Position();
            position.ID_Faculty = 7;
            position.Name_Position = "Trưởng Khoa Khoa";
            position.Cent_Position = 50;
            position.Note_Position = " Số giờ giảm 90 tiêt";
            position.Respon_Position = "là gì nhỉ";

            Teacher teachers = new Teacher();
            teachers.ID_Teacher = Convert.ToString(00000055);
            teachers.ID_Subject = 17;
            teachers.ID_Position = 16;
            teachers.ID_Ranks = 1;
            teachers.ID_Wage = 14;
            teachers.First_Name = "Nguyễn   ";
            teachers.Last_Name = "Hồng Hoa";
            teachers.Name_Teacher = "Nguyễn Hồng Hoa";
            teachers.Gende_Teacher = true;
            teachers.Phone__Teacher = "0343584329";
            teachers.Email_Teacher = "hoahong00@gmail.com";
            teachers.Address_Teacher = " Văn Giang Hưng Yên";
            teachers.Nation_Teacher = "Dân tộc Kinh";
            teachers.Religion_Teacher = "Phật Giáo";
            teachers.Level_Teacher = "Thạc sĩ";
            teachers.Experience_Teacher = "Hơn 7 năm kinh nghiệm trong nghề giáo";

            position.Teachers.Add(teachers);

            faculty.Teacher_Position.Add(position);

            _context.Teacher_Faculty.Add(faculty);
            _context.SaveChanges();


            var teacher_Faculty = await _context.Teacher_Faculty
                .Include(pub => pub.Teacher_Subject)
                .ThenInclude(subject => subject.Teachers)
                .Include(pub => pub.Teacher_Position)
                .ThenInclude(positon => positon.Teachers)
                .Where(pub => pub.ID_Faculty == faculty.ID_Faculty)
                .FirstOrDefaultAsync();


            if (teacher_Faculty == null)
            {
                return NotFound();
            }

            return teacher_Faculty;
        }

        //[HttpGet("getfactulty")]
        //public async Task<ActionResult<IEnumerable<Teacher_Faculty>>> GetTeacher_Faculty1(int id)
        //{
        //    var teacher_Faculty =await _context.Teacher_Faculty
        //        .Include(pub => pub.Teacher_Position)
        //        .ThenInclude(pub => pub.Teachers)
        //        .ToListAsync();

        //    if (teacher_Faculty == null)
        //    {
        //        return NotFound();
        //    }

        //    return teacher_Faculty;
        //}

        //[HttpGet("getfaculty")]
        //public async Task<ActionResult<Teacher_Faculty>> GetTeacher1()
        //{
        //    var teacher1 = _context.Teacher_Faculty
        //        .Include(pub => pub.Teacher_Position)
        //        .ThenInclude(pub => pub.Teachers)
        //        .FirstOrDefault();

        //    if (teacher1 == null)
        //    {
        //        return NotFound();
        //    }

        //    return teacher1;
        //}


        // PUT: api/Teacher_Faculty/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher_Faculty(int id, Teacher_Faculty teacher_Faculty)
        {
            if (id != teacher_Faculty.ID_Faculty)
            {
                return BadRequest();
            }

            _context.Entry(teacher_Faculty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Teacher_FacultyExists(id))
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

        // POST: api/Teacher_Faculty
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher_Faculty>> PostTeacher_Faculty(Teacher_Faculty teacher_Faculty)
        {
            _context.Teacher_Faculty.Add(teacher_Faculty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeacher_Faculty", new { id = teacher_Faculty.ID_Faculty }, teacher_Faculty);
        }

        // DELETE: api/Teacher_Faculty/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher_Faculty>> DeleteTeacher_Faculty(int id)
        {
            var teacher_Faculty = await _context.Teacher_Faculty.FindAsync(id);
            if (teacher_Faculty == null)
            {
                return NotFound();
            }

            _context.Teacher_Faculty.Remove(teacher_Faculty);
            await _context.SaveChangesAsync();

            return teacher_Faculty;
        }

        private bool Teacher_FacultyExists(int id)
        {
            return _context.Teacher_Faculty.Any(e => e.ID_Faculty == id);
        }
    }
}
