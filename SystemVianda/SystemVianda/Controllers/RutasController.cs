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
    public class RutasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Rutas
        public ActionResult Index()
        {
            return View(db.Rutas.ToList());
        }

        // GET: Rutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblRutas tblRutas = db.Rutas.Find(id);
            if (tblRutas == null)
            {
                return HttpNotFound();
            }
            return View(tblRutas);
        }

        // GET: Rutas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rutas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRuta,Nombre,Descripcion")] TblRutas tblRutas)
        {
            if (ModelState.IsValid)
            {
                db.Rutas.Add(tblRutas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblRutas);
        }

        // GET: Rutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblRutas tblRutas = db.Rutas.Find(id);
            if (tblRutas == null)
            {
                return HttpNotFound();
            }
            return View(tblRutas);
        }

        // POST: Rutas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRuta,Nombre,Descripcion")] TblRutas tblRutas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRutas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblRutas);
        }

        // GET: Rutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblRutas tblRutas = db.Rutas.Find(id);
            if (tblRutas == null)
            {
                return HttpNotFound();
            }
            return View(tblRutas);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblRutas tblRutas = db.Rutas.Find(id);
            db.Rutas.Remove(tblRutas);
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
