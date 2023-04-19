using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KursController : ControllerBase
    {
        private readonly IKursRepository _repo;
        private readonly IStudentKursRepository _repoStudentKurs;

        public KursController(IKursRepository repo, IStudentKursRepository repoStudentKurs)
        {
            _repo = repo;
            _repoStudentKurs = repoStudentKurs;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Kurs>>> GetKursevi()
        {
            try
            {
                var kursevi = await _repo.GetKursevi();
                if (kursevi.Count < 1)
                    return BadRequest("Nema kurseva");
                return Ok(kursevi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kurs>> GetKurs(int id)
        {
            try
            {
                return Ok(await _repo.GetKursByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveKurs(Kurs kurs)//treba da brise i sve studentkurs u kojima se nalazi
        {
            try
            {
                await _repoStudentKurs.RemoveStudentKursByKursID(kurs.ID);
                await _repo.RemoveKurs(kurs);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddKurs(Kurs kurs)
        {
            try
            {
                await _repo.AddKurs(kurs);
                return Ok("Uspesno dodat Kurs");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
