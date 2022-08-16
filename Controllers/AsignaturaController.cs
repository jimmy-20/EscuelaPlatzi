using Curso_de_ASP.NET.Models;
using Curso_de_ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.NET.Controllers
{
    [Route("[controller]")]
    public class AsignaturaController : Controller  
    {
        private Crud<Asignatura> AsignaturaServices;

        public AsignaturaController(Crud<Asignatura> services)
        {
            AsignaturaServices = services;            
        }

        [Route("Buscar/{id}")]
        public IActionResult Index(string id){
            if (!string.IsNullOrEmpty(id)){
                var asignatura = from asig in AsignaturaServices.Get()
                                 where asig.Id == id
                                 select asig;
                return View(asignatura.ToList());
            }else
            {
                return View("MultiAsignatura",AsignaturaServices.Get());
            }
        }


        public IActionResult Index(){
            return View(AsignaturaServices.Get());
        }

        [HttpPost]
        [Route("Crear")]
        public IActionResult Create(Asignatura a){
            if (ModelState.IsValid){
                AsignaturaServices.Crear(a);
                return View("Index",AsignaturaServices.Get());
            }else{
                return View();
            }
        }

        [Route("Crear")]
        public IActionResult Create(){
            return View();
        }
    }
}