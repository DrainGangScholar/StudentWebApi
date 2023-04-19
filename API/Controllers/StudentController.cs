using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IStudentRepository _repo;

        public StudentController(IStudentService service, IStudentRepository repo)
        {
            _service = service;
            _repo = repo;
        }
        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            try
            {
                await _repo.AddStudent(student);
                return Ok("Uspesno dodat Student");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id)
        {
            try
            {
                return await _repo.GetStudentByID(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Student>>> GetStudenti()
        {
            try
            {
                var students = await _repo.GetStudenti();
                if (students.Count < 1)
                    return BadRequest("Nema studenta");
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> RemoveStudent(Student student)
        {
            try
            {
                await _repo.RemoveStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}