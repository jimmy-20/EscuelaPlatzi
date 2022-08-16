using Curso_de_ASP.NET.Models;
using Curso_de_ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Curso_de_ASP.Controllers
{
    [Route("[controller]")]
    public class CursoController : Controller
    {
        private Crud<Curso> CursoServices;

        public CursoController(Crud<Curso> services)
        {
            CursoServices = services;
        }

        //[Route("Curso/")]
        [Route("Buscar/{id}")]
        public IActionResult Index(string id){
            if (!string.IsNullOrEmpty(id)){
                var curso = from c in CursoServices.Get()
                            where c.Id == id
                            select c;
                return View("MultiCurso",curso.ToList());
            }else{
                return View(CursoServices.Get());
            }
        }

        public IActionResult Index(){
            return View("MultiCurso",CursoServices.Get().ToList());
        }

        [Route("Create")]
        public IActionResult Create(){
            return View();
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Curso c){
            if(ModelState.IsValid){
               CursoServices.Crear(c);
               return View();
            }else{
                return View(c);
            }
        }
    }
}