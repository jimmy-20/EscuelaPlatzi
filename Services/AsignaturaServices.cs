using Curso_de_ASP.NET.Context;
using Curso_de_ASP.NET.Models;

namespace Curso_de_ASP.Services
{
    public class AsignaturaServices: Crud<Asignatura>
    {
        private EscuelaContext Context;

        public AsignaturaServices(EscuelaContext context)
        {
            Context = context;
        }

        public void Actualizar(string id, Asignatura t)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(string id)
        {
            throw new NotImplementedException();
        }

        public void Crear(Asignatura t)
        {
            Context.Add(t);
            Context.SaveChanges();
        }

        public List<Asignatura> Get()
        {
            return Context.Asignatura.ToList();
        }
    }
}