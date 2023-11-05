using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Alunos: Marta, Paula, Lucas, Rafa");
        }
    }
}
