using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() { 
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Martins",
                Telefone = "12345678"
            },
            new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Almeida",
                Telefone = "87654321"
            },
            new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Lopes",
                Telefone = "78456123"
            },
            new Aluno()
            {
                Id = 4,
                Nome = "Rafael",
                Sobrenome = "Gonçalves",
                Telefone = "45444545"
            }
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O aluno(a) não foi encontrado(a).");
            }
            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var aluno = Alunos.FindAll(a => a.Nome.Contains(nome));

            if (!aluno.Any())
            {
                return BadRequest("O aluno(a) não foi encontrado(a).");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno) 
        { 
            return Ok(); 
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
