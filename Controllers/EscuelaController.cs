using Curso_de_ASP.NET.Context;
using Curso_de_ASP.NET.Models;
using Curso_de_ASP.NET.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET.Controllers
{
    public class EscuelaController : Controller  
    {
        private IEscuelaServices escuelaServices;

        public EscuelaController(IEscuelaServices es)
        {
            escuelaServices = es;
        }
        public IActionResult Index(){
            return View(escuelaServices.GetEscuelas().FirstOrDefault());
        }
    }
}