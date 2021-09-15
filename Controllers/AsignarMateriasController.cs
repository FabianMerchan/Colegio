using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Colegio.Models;



namespace Colegio.Controllers
{
    public class AsignarMateriasController : Controller
    {


        private colegioContext db = new colegioContext();

        // GET: AsignarMaterias
        public ActionResult Index()
        {

            List<Alumnos> lEstudiantes = new List<Alumnos>();
            lEstudiantes = db.Alumno.ToList();
            ViewBag.listaAlumnos = lEstudiantes;

            List<Asignaturas> lAsignaturaAlumno = new List<Asignaturas>();
            lAsignaturaAlumno = db.Asignatura.ToList();
            ViewBag.listaAsignaturaAlumno = lAsignaturaAlumno;


            List<Asignaturas> lAsignaturaProfesor = new List<Asignaturas>();
            lAsignaturaProfesor = db.Asignatura.ToList();
            ViewBag.listaAsignaturaProfesor = lAsignaturaProfesor;

            List<Profesores> lProfesores = new List<Profesores>();
            lProfesores = db.Profesor.ToList();
            ViewBag.listaProfesores = lProfesores;



          

  

            return View();

        }


        // GET: Profesores/Create
        public ActionResult AsignarProfesor()
        {
            return View();
        }

        // POST: Profesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsignarProfesor([Bind(Include = "Id,IdAsignatura,IdProfesor")] AsignacionProfesores asignacionProfesores)
        {
            if (ModelState.IsValid)
            {
                string idAsig =  asignacionProfesores.IdAsignatura.ToString();
                string idProfe = asignacionProfesores.IdProfesor.ToString();


                string query = "select * from AsignacionProfesores where idAsignatura ="+ idAsig + " ";


                var report = db.AsignacionProfesor.SqlQuery(query).ToList();

                if (report.Count >= 1)
                {
                    TempData["MensajeProfesor"] = "La Materia ya se encuentra asignada ";

                    return RedirectToAction("Index");
                    
                }
                else
                {
                    db.AsignacionProfesor.Add(asignacionProfesores);
                    db.SaveChanges();
                    TempData["MensajeProfesor"] = "Asignacion Correcta";
                    return RedirectToAction("Index");
                }
                     

                
            }

            return View(asignacionProfesores);
        }





        // GET: Profesores/Create
        public ActionResult AsignarAlumno()
        {
            return View();
        }

        // POST: Profesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsignarAlumno([Bind(Include = "Id,IdAsignatura,IdAlumno,Anio,Calificacion")] AsignacionAlumnos asignacionAlumnos)
        {
            if (ModelState.IsValid)
            {


                string idAsig = asignacionAlumnos.IdAsignatura.ToString();
                string Ani = asignacionAlumnos.Anio.ToString();


                string query = "select * from AsignacionAlumnos where IdAsignatura =" + idAsig + " and Anio = '"+ Ani + "'";


                var report = db.AsignacionAlumno.SqlQuery(query).ToList();

                if (report.Count >= 1)
                {

                    TempData["MensajeAlumno"] = "El Alumno ya tiene asociada una materia en el año "+ Ani + "";
                    return RedirectToAction("Index");

                }
                else
                {

                    db.AsignacionAlumno.Add(asignacionAlumnos);
                    db.SaveChanges();
                    TempData["MensajeAlumno"] = "Asignacion Correcta";
                    return RedirectToAction("Index");
                }


            }

            return View(asignacionAlumnos);



        }
    }
}
