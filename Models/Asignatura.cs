using System;

namespace Curso_de_ASP.NET.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public string CursoId { get; set; }
        public Curso? Curso { get; set; }
        public List<Evaluación>? Evaluaciones { get; set; }
    }
}