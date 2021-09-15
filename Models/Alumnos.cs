using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Colegio.Models
{
    public class Alumnos
    {
   
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int telefono { get; set; }
        public AsignacionAlumnos AsignacionAlumno { get; set; }       

    }
}