using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Colegio.Models
{
    public class AsignacionProfesores
    {
     
        public int Id { get; set; }
        [Required]
        public int IdAsignatura { get; set; }
        [Required]
        public int IdProfesor { get; set; }     
        public ICollection<Profesores> Profesor { get; set; }        

    }
}