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
        private readonly IStudentRepository _repoStudent;
        private readonly IKursRepository _repoKurs;

        public StudentKursController(IStudentKursService service, IStudentKursRepository repo,
        IStudentRepository repoStudent,IKursRepository repoKurs)
        {
            _service = service;
            _repo = repo;
            _repoStudent=repoStudent;
            _repoKurs=repoKurs;
        }
    }
}