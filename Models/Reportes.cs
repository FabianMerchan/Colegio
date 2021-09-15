using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Colegio.Models
{
    public class Reportes
    {
        public int Id { get; set; }
        public string Profesor { get; set; }
        public int ID_Profesor { get; set; }
        public string Alumno { get; set; }
        public int ID_Alumno { get; set; }
        public string Asignatura { get; set; }
        public int ID_Asignatura { get; set; }
        public string Anio { get; set; }

        public float Calificacion_Final { get; set; }
        public string Aprobo { get; set; }
    }
}