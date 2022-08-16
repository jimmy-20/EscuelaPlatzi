using Curso_de_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET.Controllers
{
    public class AlumnoController : Controller  
    {
        public IActionResult Index(){
           // IEnumerable<Alumno> alumnos = 

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View(); //Por convencion la vista retornada es la del nombre del metodo
        }
    }
}