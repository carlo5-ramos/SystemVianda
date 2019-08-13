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
    public class ComController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Com
        public ActionResult Index()
        {
            var compras = db.Compras.Include(t => t.Proveedores).Include(t => t.Usuarios);
            return View(compras.ToList());
        }

        // GET: Com/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCompras tblCompras = db.Compras.Find(id);
            if (tblCompras == null)
            {
                return HttpNotFound();
            }
            return View(tblCompras);
        }

        // GET: Com/Create
        public ActionResult Create()
        {
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Empresa");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario");
            return View();
        }

        // POST: Com/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompra,CodigoFactura,IdProveedor,IdUsuario,FecCompra,FechaRegistro,Estado,Descripcion")] TblCompras tblCompras)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(tblCompras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Empresa", tblCompras.IdProveedor);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", tblCompras.IdUsuario);
            return View(tblCompras);
        }

        // GET: Com/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCompras tblCompras = db.Compras.Find(id);
            if (tblCompras == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Empresa", tblCompras.IdProveedor);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", tblCompras.IdUsuario);
            return View(tblCompras);
        }

        // POST: Com/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompra,CodigoFactura,IdProveedor,IdUsuario,FecCompra,FechaRegistro,Estado,Descripcion")] TblCompras tblCompras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCompras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Empresa", tblCompras.IdProveedor);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Usuario", tblCompras.IdUsuario);
            return View(tblCompras);
        }

        // GET: Com/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCompras tblCompras = db.Compras.Find(id);
            if (tblCompras == null)
            {
                return HttpNotFound();
            }
            return View(tblCompras);
        }

        // POST: Com/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCompras tblCompras = db.Compras.Find(id);
            db.Compras.Remove(tblCompras);
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
