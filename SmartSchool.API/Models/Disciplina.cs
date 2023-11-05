using System.Collections;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }

        public Disciplina() { }
        public Disciplina(int id, string nome, int professorId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
        }
    }
}
