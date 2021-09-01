using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical.Configuration;
using Practical.Configuration.InputModels;
using Practical.Configuration.OutputModels;
using Practical.Models;

namespace Practical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamStudentController : ControllerBase
    {
        private readonly Exam_ASPNetContext _context;

        public ExamStudentController(Exam_ASPNetContext context)
        {
            _context = context;
        }

        // GET: api/ExamStudent
        [HttpGet]
        public async Task<ActionResult<ResponseStudent>> GetExamStudents()
        {
            var res = new ResponseStudent();
            try
            {
                var lst = (from a in _context.ExamStudents
                           select new RequestStudent
                           {
                               StudentID = a.StudentId,
                               FirstName = a.FirstName,
                               LastName = a.LastName,
                               PhoneNumber = a.PhoneNumber,
                               Email = a.Email
                           }).ToList();
                res.Data = lst;
                res.Status = StatusID.Success;
                res.Message = "Thành công !";
            }
            catch (Exception ex)
            {
                res.Status = StatusID.InternalServer;
                res.Message = ex.Message;
            }

            return await Task.FromResult(res);
        }

        // GET: api/ExamStudent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamStudent>> GetExamStudent(int id)
        {
            var examStudent = await _context.ExamStudents.FindAsync(id);

            if (examStudent == null)
            {
                return NotFound();
            }

            return examStudent;
        }

        // PUT: api/ExamStudent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamStudent(int id, ExamStudent examStudent)
        {
            if (id != examStudent.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(examStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamStudentExists(id))
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

        // POST: api/ExamStudent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamStudent>> PostExamStudent(ExamStudent examStudent)
        {
            _context.ExamStudents.Add(examStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamStudent", new { id = examStudent.StudentId }, examStudent);
        }

        // DELETE: api/ExamStudent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamStudent(int id)
        {
            var examStudent = await _context.ExamStudents.FindAsync(id);
            if (examStudent == null)
            {
                return NotFound();
            }

            _context.ExamStudents.Remove(examStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamStudentExists(int id)
        {
            return _context.ExamStudents.Any(e => e.StudentId == id);
        }
    }
}
