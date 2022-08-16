using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        public override string Nombre {get;set;}
        public TiposJornada Jornada { get; set; }
        public virtual List<Asignatura>? Asignaturas{ get; set; }
        public List<Alumno>? Alumnos{ get; set; }

        public string? Dirección { get; set; }
        public virtual string? EscuelaId { get; set; }
        public virtual Escuela? Escuela {get;set;}
    }
}