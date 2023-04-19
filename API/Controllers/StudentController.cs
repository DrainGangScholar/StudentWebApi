using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        private readonly IStudentKursRepository _repoStudentKurs;

        public StudentController(IStudentRepository repo, IStudentKursRepository repoStudentKurs)
        {
            _repo = repo;
            _repoStudentKurs = repoStudentKurs;
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
                var studenti = await _repo.GetStudenti();
                if (studenti.Count < 1)
                    return BadRequest("Nema studenta");
                return Ok(studenti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> RemoveStudent(Student student)//treba da brise i sve studentkurs u kojima se nalazi
        {
            try
            {
                await _repoStudentKurs.RemoveStudentKursByStudentID(student.ID);
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