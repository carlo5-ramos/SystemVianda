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
    public class ProveedoresController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Proveedores
        public ActionResult Index()
        {
            var proveedores = db.Proveedores.Include(t => t.Usuarios);
            return View(proveedores.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedores tblProveedores = db.Proveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedores);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario");
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProveedor,Empresa,Contacto,Telefono,Direccion,Email,Nrc,Nit,Web,FechaRegistro,IdUsuario")] TblProveedores tblProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(tblProveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", tblProveedores.IdUsuario);
            return View(tblProveedores);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedores tblProveedores = db.Proveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", tblProveedores.IdUsuario);
            return View(tblProveedores);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProveedor,Empresa,Contacto,Telefono,Direccion,Email,Nrc,Nit,Web,FechaRegistro,IdUsuario")] TblProveedores tblProveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", tblProveedores.IdUsuario);
            return View(tblProveedores);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProveedores tblProveedores = db.Proveedores.Find(id);
            if (tblProveedores == null)
            {
                return HttpNotFound();
            }
            return View(tblProveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProveedores tblProveedores = db.Proveedores.Find(id);
            db.Proveedores.Remove(tblProveedores);
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
