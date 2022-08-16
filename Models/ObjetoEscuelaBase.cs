using System;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET.Models
{
    public abstract class ObjetoEscuelaBase
    {
        public string Id  = Guid.NewGuid().ToString();
        public virtual string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
        }

        public override string ToString()
        {
            return $"{Nombre},{Id}";
        }
    }
}