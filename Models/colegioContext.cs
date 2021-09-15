using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Colegio.Models
{
    public class colegioContext : DbContext
    {
        public colegioContext() : base("connColegio")
        {

        }
        
        public DbSet<Alumnos> Alumno { get; set; }
        public DbSet<Profesores> Profesor { get; set; }
        public DbSet<Asignaturas> Asignatura { get; set; }
        public DbSet<AsignacionProfesores> AsignacionProfesor { get; set; }
        public DbSet<AsignacionAlumnos> AsignacionAlumno { get; set; }


    }
}