namespace Curso_de_ASP.Services
{
    public interface Crud<T>
    {
        void Crear(T t);
        void Actualizar(string id, T t);
        List<T> Get();
        bool Borrar(string id);
    }
}