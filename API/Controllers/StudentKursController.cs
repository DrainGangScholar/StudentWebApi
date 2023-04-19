using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentKursController : ControllerBase
    {
        private readonly IStudentKursRepository _repo;
        private readonly IStudentRepository _repoStudent;
        private readonly IKursRepository _repoKurs;

        public StudentKursController(IStudentKursRepository repo, IStudentRepository repoStudent, IKursRepository repoKurs)
        {
            _repo = repo;
            _repoStudent = repoStudent;
            _repoKurs = repoKurs;
        }
    }
}