using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Colegio.Models;

namespace Colegio.Controllers
{
    public class ReporteController : Controller
    {
        private colegioContext db = new colegioContext();
        // GET: Reporte
        public ActionResult Index()
        {

            var query = from AP in db.AsignacionProfesor
                        join P in db.Profesor on AP.IdProfesor equals P.Id
                        join AS in db.Asignatura on AP.IdAsignatura equals AS.Id
                        join AA in db.AsignacionAlumno on AS.Id equals AA.IdAsignatura
                        join AL in db.Alumno on AA.IdAlumno equals AL.Id
                        select new Reportes
                        {
                            Id = 1,
                            Profesor = P.Nombre,
                            ID_Profesor = P.Id,
                            Alumno = AL.Nombre,
                            ID_Alumno = AL.Id,
                            Asignatura = AS.Nombre,
                            ID_Asignatura = AS.Id,
                            Anio = AA.Anio,
                            Calificacion_Final = AA.Calificacion,
                            Aprobo = "2"
                        };

            var report = query.ToList();
        


            return View(report);
        }
    }
}