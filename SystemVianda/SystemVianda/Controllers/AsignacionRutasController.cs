using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemVianda.Models;

namespace SystemVianda.Controllers
{
    public class AsignacionRutasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: AsignacionRutas
        public ActionResult Index()
        {
            var asignacionRutas = db.AsignacionRutas.Include(t => t.Empleado).Include(t => t.Rutas);
            return View(asignacionRutas.ToList());
        }

        // GET: AsignacionRutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblAsignacionRuta tblAsignacionRuta = db.AsignacionRutas.Find(id);
            if (tblAsignacionRuta == null)
            {
                return HttpNotFound();
            }
            return View(tblAsignacionRuta);
        }

        // GET: AsignacionRutas/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre");
            return View();
        }

        // POST: AsignacionRutas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsignacionRuta,IdRuta,IdEmpleado,Fecha")] TblAsignacionRuta tblAsignacionRuta)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionRutas.Add(tblAsignacionRuta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", tblAsignacionRuta.IdEmpleado);
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre", tblAsignacionRuta.IdRuta);
            return View(tblAsignacionRuta);
        }

        // GET: AsignacionRutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblAsignacionRuta tblAsignacionRuta = db.AsignacionRutas.Find(id);
            if (tblAsignacionRuta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", tblAsignacionRuta.IdEmpleado);
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre", tblAsignacionRuta.IdRuta);
            return View(tblAsignacionRuta);
        }

        // POST: AsignacionRutas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAsignacionRuta,IdRuta,IdEmpleado,Fecha")] TblAsignacionRuta tblAsignacionRuta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAsignacionRuta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", tblAsignacionRuta.IdEmpleado);
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre", tblAsignacionRuta.IdRuta);
            return View(tblAsignacionRuta);
        }

        // GET: AsignacionRutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblAsignacionRuta tblAsignacionRuta = db.AsignacionRutas.Find(id);
            if (tblAsignacionRuta == null)
            {
                return HttpNotFound();
            }
            return View(tblAsignacionRuta);
        }

        // POST: AsignacionRutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblAsignacionRuta tblAsignacionRuta = db.AsignacionRutas.Find(id);
            db.AsignacionRutas.Remove(tblAsignacionRuta);
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
