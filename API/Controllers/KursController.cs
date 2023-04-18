using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KursController : ControllerBase
    {
        private readonly IKursService _service;
        private readonly IKursRepository _repo;

        public KursController(IKursService service, IKursRepository repo)
        {
            _service = service;
            _repo = repo;
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
        public async Task<ActionResult<Kurs>> GetKursById(int id)
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
    }
}