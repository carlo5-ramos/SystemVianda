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
    public class CategoriasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCategorias tblCategorias = db.Categorias.Find(id);
            if (tblCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorias);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoria,Categoria,Descripcion")] TblCategorias tblCategorias)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(tblCategorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCategorias);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCategorias tblCategorias = db.Categorias.Find(id);
            if (tblCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoria,Categoria,Descripcion")] TblCategorias tblCategorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCategorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCategorias);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCategorias tblCategorias = db.Categorias.Find(id);
            if (tblCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tblCategorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCategorias tblCategorias = db.Categorias.Find(id);
            db.Categorias.Remove(tblCategorias);
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
