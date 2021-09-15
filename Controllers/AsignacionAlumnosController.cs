using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio.Models;

namespace Colegio.Controllers
{
    public class AsignacionAlumnosController : Controller
    {
        private colegioContext db = new colegioContext();

        // GET: AsignacionAlumnos
        public ActionResult Index()
        {
            return View(db.AsignacionAlumno.ToList());
        }

        // GET: AsignacionAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionAlumnos asignacionAlumnos = db.AsignacionAlumno.Find(id);
            if (asignacionAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(asignacionAlumnos);
        }

        // GET: AsignacionAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsignacionAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAsignatura,IdAlumno,Anio,Calificacion")] AsignacionAlumnos asignacionAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionAlumno.Add(asignacionAlumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignacionAlumnos);
        }

        // GET: AsignacionAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionAlumnos asignacionAlumnos = db.AsignacionAlumno.Find(id);
            if (asignacionAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(asignacionAlumnos);
        }

        // POST: AsignacionAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAsignatura,IdAlumno,Anio,Calificacion")] AsignacionAlumnos asignacionAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionAlumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignacionAlumnos);
        }

        // GET: AsignacionAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionAlumnos asignacionAlumnos = db.AsignacionAlumno.Find(id);
            if (asignacionAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(asignacionAlumnos);
        }

        // POST: AsignacionAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionAlumnos asignacionAlumnos = db.AsignacionAlumno.Find(id);
            db.AsignacionAlumno.Remove(asignacionAlumnos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
