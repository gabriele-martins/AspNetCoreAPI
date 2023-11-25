using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);

            if (professor == null)
            {
                return BadRequest("Professor(a) não foi encontrado(a).");
            }
            return Ok(professor);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.Where(p => p.Nome.Contains(nome));

            if (!professor.Any())
            {
                return BadRequest("Professor(a) não foi encontrado(a).");
            }
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor(a) não foi encontrado(a).");
            }

            _context.Update(professor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor(a) não foi encontrado(a).");
            }

            _context.Update(professor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null)
            {
                return BadRequest("Professor(a) não foi encontrado(a).");
            }

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
