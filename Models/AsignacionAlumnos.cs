using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class AsignacionAlumnos
    {
        public int Id { get; set; }
        [Required]
        public int IdAsignatura { get; set; }
        [Required]
        public int IdAlumno { get; set; }
        [Required]
        public string Anio { get; set; }
        [Required]
        public float Calificacion { get; set; }

        public ICollection<Alumnos> Alumno { get; set; }

    }
}