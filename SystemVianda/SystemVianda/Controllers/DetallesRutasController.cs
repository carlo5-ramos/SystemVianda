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
    public class DetallesRutasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: DetallesRutas
        public ActionResult Index()
        {
            var detallesRutas = db.DetallesRutas.Include(t => t.Clientes).Include(t => t.Rutas);
            return View(detallesRutas.ToList());
        }

        // GET: DetallesRutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDetallesRuta tblDetallesRuta = db.DetallesRutas.Find(id);
            if (tblDetallesRuta == null)
            {
                return HttpNotFound();
            }
            return View(tblDetallesRuta);
        }

        // GET: DetallesRutas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre");
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre");
            return View();
        }

        // POST: DetallesRutas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetallesRuta,IdRuta,IdCliente")] TblDetallesRuta tblDetallesRuta)
        {
            if (ModelState.IsValid)
            {
                db.DetallesRutas.Add(tblDetallesRuta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", tblDetallesRuta.IdCliente);
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre", tblDetallesRuta.IdRuta);
            return View(tblDetallesRuta);
        }

        // GET: DetallesRutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDetallesRuta tblDetallesRuta = db.DetallesRutas.Find(id);
            if (tblDetallesRuta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", tblDetallesRuta.IdCliente);
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre", tblDetallesRuta.IdRuta);
            return View(tblDetallesRuta);
        }

        // POST: DetallesRutas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetallesRuta,IdRuta,IdCliente")] TblDetallesRuta tblDetallesRuta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDetallesRuta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombre", tblDetallesRuta.IdCliente);
            ViewBag.IdRuta = new SelectList(db.Rutas, "IdRuta", "Nombre", tblDetallesRuta.IdRuta);
            return View(tblDetallesRuta);
        }

        // GET: DetallesRutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDetallesRuta tblDetallesRuta = db.DetallesRutas.Find(id);
            if (tblDetallesRuta == null)
            {
                return HttpNotFound();
            }
            return View(tblDetallesRuta);
        }

        // POST: DetallesRutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblDetallesRuta tblDetallesRuta = db.DetallesRutas.Find(id);
            db.DetallesRutas.Remove(tblDetallesRuta);
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
