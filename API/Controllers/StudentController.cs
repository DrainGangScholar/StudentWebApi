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
    }
}