using Curso_de_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Curso_de_ASP.NET.Context
{
    public class EscuelaContext : DbContext 
    {
        public  DbSet <Escuela> Escuela {get;set;}
        public  DbSet <Asignatura> Asignatura {get;set;}
        public  DbSet <Curso> Curso {get;set;}
        public  DbSet <Alumno> Alumno {get;set;}
        public  DbSet <Evaluación> Evaluacion {get;set;}

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base (options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Escuela>(escuela => {
                escuela.HasKey(e => e.Id).HasName("IdEscuela");
                escuela.Property(e => e.Nombre).HasMaxLength(50);
                escuela.Property(e => e.Dirección).HasMaxLength(50);
                escuela.Property(e => e.Pais).HasMaxLength(50);
                escuela.Property(e => e.Ciudad).HasMaxLength(50);
                escuela.Property(e => e.TipoEscuela);
                escuela.Property(e => e.AñoDeCreación);
            });

            builder.Entity<Curso>(curso => {
                curso.HasKey(c => c.Id).HasName("IdCurso");
                curso.HasOne(c => c.Escuela).WithMany(e => e.Cursos).HasForeignKey(c => c.EscuelaId);
                curso.Property(c => c.Nombre).HasMaxLength(50);
                curso.Property(c => c.Dirección);
                curso.Property(c => c.Jornada);
            });

            builder.Entity<Asignatura>(asignatura => {
                asignatura.HasKey(a => a.Id);
                asignatura.HasOne(a => a.Curso).WithMany(c => c.Asignaturas).HasForeignKey(a => a.CursoId);

                asignatura.Property(a => a.Nombre).HasMaxLength(50);
            });

            builder.Entity<Alumno>(alumno => {
                alumno.HasKey(a => a.Id);
                alumno.HasOne(a => a.Curso).WithMany(c => c.Alumnos).HasForeignKey(a => a.CursoId);

                alumno.Property(a => a.Nombre).HasMaxLength(50);
            });

            builder.Entity<Evaluación>(evaluacion => {
                evaluacion.HasKey(e => e.Id);
                evaluacion.HasOne(e => e.Alumno).WithMany(a => a.Evaluaciones).HasForeignKey(e => e.AlumnoId);
                evaluacion.HasOne(e => e.Asignatura).WithMany(a => a.Evaluaciones).HasForeignKey(e =>  e.AsignaturaId);
                evaluacion.Property(e => e.Nota);
            }); 

            Escuela e = CargarEscuela();
            builder.Entity<Escuela>().HasData(e);

            List<Curso> cursos = CargarCurso(e);
            builder.Entity<Curso>().HasData(cursos);

            List<Asignatura> asignaturas = CargarAsignaturas(cursos);
            builder.Entity<Asignatura>().HasData(asignaturas);

            List<Alumno> alumnos = CargarAlumnos(cursos);
            builder.Entity<Alumno>().HasData(alumnos);
        }

        private List<Curso> CargarCurso(Escuela e)
        {
            List<Curso> cursos = new List<Curso>();

            cursos.Add(new Curso(){
                Nombre = "Estadistica",
                EscuelaId = e.Id
            });

            cursos.Add(new Curso(){
                Nombre = "Ingeniera de Software",
                EscuelaId = e.Id
            });

            return cursos;
        }

        private static List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(new Alumno()
            {
                Nombre = "Pepito",
                CursoId = cursos.ToArray()[0].Id
            });
            alumnos.Add(new Alumno()
            {
                Nombre = "Pablo",
                CursoId = cursos.ToArray()[0].Id
            });
            alumnos.Add(new Alumno()
            {
                Nombre = "José",
                CursoId = cursos.ToArray()[1].Id
            });
            return alumnos;
        }

        private static Escuela CargarEscuela()
        {
            Escuela e = new Escuela();
            e.AñoDeCreación = 2022;
            e.Nombre = "Platzi";
            e.Pais = "Nicaragua";
            e.Ciudad = "Managua";
            e.Dirección = "Avenida siempre viva";
            e.TipoEscuela = TiposEscuela.Secundaria;
            return e;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            List<Asignatura> asignaturas = new List<Asignatura>();
            asignaturas.Add(new Asignatura()
            {
                Nombre = "Programación",
                CursoId = cursos.ToArray()[1].Id
            });
            asignaturas.Add(new Asignatura()
            {
                Nombre = "Matematicas",
                CursoId = cursos.ToArray()[0].Id
            });
            asignaturas.Add(new Asignatura()
            {
                Nombre = "Fisica",
               CursoId = cursos.ToArray()[0].Id
            });

            return asignaturas;
        }
    }
}