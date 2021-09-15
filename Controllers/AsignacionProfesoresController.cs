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
    public class AsignacionProfesoresController : Controller
    {
        private colegioContext db = new colegioContext();

        // GET: AsignacionProfesores
        public ActionResult Index()
        {
            return View(db.AsignacionProfesor.ToList());
        }

        // GET: AsignacionProfesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionProfesores asignacionProfesores = db.AsignacionProfesor.Find(id);
            if (asignacionProfesores == null)
            {
                return HttpNotFound();
            }
            return View(asignacionProfesores);
        }

        // GET: AsignacionProfesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsignacionProfesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAsignatura,IdProfesor")] AsignacionProfesores asignacionProfesores)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionProfesor.Add(asignacionProfesores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignacionProfesores);
        }

        // GET: AsignacionProfesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionProfesores asignacionProfesores = db.AsignacionProfesor.Find(id);
            if (asignacionProfesores == null)
            {
                return HttpNotFound();
            }
            return View(asignacionProfesores);
        }

        // POST: AsignacionProfesores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAsignatura,IdProfesor")] AsignacionProfesores asignacionProfesores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionProfesores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignacionProfesores);
        }

        // GET: AsignacionProfesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionProfesores asignacionProfesores = db.AsignacionProfesor.Find(id);
            if (asignacionProfesores == null)
            {
                return HttpNotFound();
            }
            return View(asignacionProfesores);
        }

        // POST: AsignacionProfesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionProfesores asignacionProfesores = db.AsignacionProfesor.Find(id);
            db.AsignacionProfesor.Remove(asignacionProfesores);
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
