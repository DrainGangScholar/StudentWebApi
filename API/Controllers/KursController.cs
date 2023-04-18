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
    }
}