using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentKursController : ControllerBase
    {
        private readonly IStudentKursService _service;
        private readonly IStudentKursRepository _repo;

        public StudentKursController(IStudentKursService service, IStudentKursRepository repo)
        {
            _service = service;
            _repo = repo;
        }
    }
}