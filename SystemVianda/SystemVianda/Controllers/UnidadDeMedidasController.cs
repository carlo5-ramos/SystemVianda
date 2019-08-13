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
    public class UnidadDeMedidasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: UnidadDeMedidas
        public ActionResult Index()
        {
            return View(db.UnidadDeMedidas.ToList());
        }

        // GET: UnidadDeMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUnidadDeMedida tblUnidadDeMedida = db.UnidadDeMedidas.Find(id);
            if (tblUnidadDeMedida == null)
            {
                return HttpNotFound();
            }
            return View(tblUnidadDeMedida);
        }

        // GET: UnidadDeMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadDeMedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUnidadMedida,Nombre,Descripcion")] TblUnidadDeMedida tblUnidadDeMedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadDeMedidas.Add(tblUnidadDeMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUnidadDeMedida);
        }

        // GET: UnidadDeMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUnidadDeMedida tblUnidadDeMedida = db.UnidadDeMedidas.Find(id);
            if (tblUnidadDeMedida == null)
            {
                return HttpNotFound();
            }
            return View(tblUnidadDeMedida);
        }

        // POST: UnidadDeMedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUnidadMedida,Nombre,Descripcion")] TblUnidadDeMedida tblUnidadDeMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUnidadDeMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUnidadDeMedida);
        }

        // GET: UnidadDeMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUnidadDeMedida tblUnidadDeMedida = db.UnidadDeMedidas.Find(id);
            if (tblUnidadDeMedida == null)
            {
                return HttpNotFound();
            }
            return View(tblUnidadDeMedida);
        }

        // POST: UnidadDeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblUnidadDeMedida tblUnidadDeMedida = db.UnidadDeMedidas.Find(id);
            db.UnidadDeMedidas.Remove(tblUnidadDeMedida);
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
