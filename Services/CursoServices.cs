using Curso_de_ASP.NET.Context;
using Curso_de_ASP.NET.Models;

namespace Curso_de_ASP.Services
{
    public class CursoServices : Crud<Curso>
    {
        private EscuelaContext Context;

        public CursoServices(EscuelaContext context)
        {
            Context =  context;
        }

        public void Actualizar(string id, Curso t)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(string id)
        {
            throw new NotImplementedException();
        }

        public void Crear(Curso t)
        {
            t.EscuelaId = Context.Escuela.FirstOrDefault().Id;
            t.Id = Guid.NewGuid().ToString();
            Context.Add(t);
            Context.SaveChanges();
        }

        public List<Curso> Get()
        {
            return Context.Curso.ToList();
        }
    }
}