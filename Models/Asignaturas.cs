using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    public class Asignaturas
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }

        public AsignacionProfesores AsignacionProfesor { get; set; }
        public AsignacionAlumnos AsignacionAlumno { get; set; }
    }
}