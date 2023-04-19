

using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentKursController : ControllerBase
    {
        private readonly IStudentKursRepository _repo;
        private readonly IStudentKursService _service;
        public StudentKursController(IStudentKursRepository repo, IStudentKursService service)
        {
            _repo = repo;
            _service = service;
        }
        [HttpGet("getocenestudentid")]
        public async Task<ActionResult<IReadOnlyList<int>>> GetOceneByStudentID(int idStudent)
        {
            try
            {
                var kursevi = await _repo.GetStudentKursByStudentID(idStudent);
                return kursevi.Select(p => p.Ocena).ToList();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getstudentkursevi")]
        public async Task<ActionResult<IReadOnlyList<StudentKurs>>> GetStudentKursevi()
        {
            try
            {
                return Ok(await _repo.GetStudentKursevi());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("addocena")]
        public async Task<ActionResult> AddOcena(Student student, Kurs kurs, int ocena)
        {
            try
            {
                if (await _repo.AddStudentKurs(new StudentKurs
                {
                    ID = 0,
                    Student = student,
                    Kurs = kurs,
                    Ocena = ocena
                }) != 0)
                {
                    return BadRequest("Greska pri dodavanju");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("prosecnaocenakurs")]
        public async Task<ActionResult<decimal>> ProsecnaOcena(int id)
        {
            var kursevi = await _repo.GetStudentKursByKursID(id);
            var ocene = kursevi.Select(p => p.Ocena).ToList();
            return _service.ProsecnaOcena(ocene);
        }
    }
}