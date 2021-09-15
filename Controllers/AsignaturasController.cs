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
    public class AsignaturasController : Controller
    {
        private colegioContext db = new colegioContext();

        // GET: Asignaturas
        public ActionResult Index()
        {
            return View(db.Asignatura.ToList());
        }

        // GET: Asignaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturas asignaturas = db.Asignatura.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            return View(asignaturas);
        }

        // GET: Asignaturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asignaturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Asignatura.Add(asignaturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asignaturas);
        }

        // GET: Asignaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturas asignaturas = db.Asignatura.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            return View(asignaturas);
        }

        // POST: Asignaturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignaturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignaturas);
        }

        // GET: Asignaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignaturas asignaturas = db.Asignatura.Find(id);
            if (asignaturas == null)
            {
                return HttpNotFound();
            }
            return View(asignaturas);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignaturas asignaturas = db.Asignatura.Find(id);
            db.Asignatura.Remove(asignaturas);
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
