using Curso_de_ASP.NET.Context;
using Curso_de_ASP.NET.Models;

namespace Curso_de_ASP.NET.Services
{
    public class EscuelaServices : IEscuelaServices
    {
        private EscuelaContext Context;

        public EscuelaServices(EscuelaContext context)
        {
            Context = context;
            Context.Database.EnsureCreated();
        }

        public IEnumerable<Escuela> GetEscuelas()
        {
            return Context.Escuela;
        }
    }

    public interface IEscuelaServices
    {
        IEnumerable<Escuela> GetEscuelas();
    }
}