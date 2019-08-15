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
    public class ProductosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(t => t.Categorias).Include(t => t.UnidadDeMedida);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProductos tblProductos = db.Productos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Categoria");
            ViewBag.IdUnidadMedida = new SelectList(db.UnidadDeMedidas, "IdUnidadMedida", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,Nombre,BarCode,Existencia,Precio,Descripcion,Estado,FechaRegistro,IdCategoria,IdUnidadMedida")] TblProductos tblProductos)
        {
            if (tblProductos.Precio <= 0)
            {
                ViewBag.Error = "Campo Precio no puede ser 0";
            }
            else
            {

                tblProductos.Estado = true;
                tblProductos.FechaRegistro = DateTime.Now.Date;
                if (ModelState.IsValid)
                {
                    db.Productos.Add(tblProductos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Categoria", tblProductos.IdCategoria);
            ViewBag.IdUnidadMedida = new SelectList(db.UnidadDeMedidas, "IdUnidadMedida", "Nombre", tblProductos.IdUnidadMedida);
            return View(tblProductos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProductos tblProductos = db.Productos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Categoria", tblProductos.IdCategoria);
            ViewBag.IdUnidadMedida = new SelectList(db.UnidadDeMedidas, "IdUnidadMedida", "Nombre", tblProductos.IdUnidadMedida);
            return View(tblProductos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Nombre,BarCode,Existencia,Precio,Descripcion,Estado,FechaRegistro,IdCategoria,IdUnidadMedida")] TblProductos tblProductos)
        {
            if (ModelState.IsValid)
                if (tblProductos.Precio <= 0)
                {
                    ViewBag.Error = "Campo Precio no puede ser 0";
                }
                else
                {

                    var query = (from p in db.Productos
                                 where p.IdProducto == tblProductos.IdProducto
                                 select p).First();
                    if (query != null)
                    {
                        db.Entry(query).State = EntityState.Detached;
                        tblProductos.Estado = query.Estado;
                        tblProductos.FechaRegistro = query.FechaRegistro;
                    }
                    if (ModelState.IsValid)
                    {
                        db.Entry(tblProductos).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "Categoria", tblProductos.IdCategoria);
            ViewBag.IdUnidadMedida = new SelectList(db.UnidadDeMedidas, "IdUnidadMedida", "Nombre", tblProductos.IdUnidadMedida);
            return View(tblProductos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProductos tblProductos = db.Productos.Find(id);
            if (tblProductos == null)
            {
                return HttpNotFound();
            }
            return View(tblProductos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProductos tblProductos = db.Productos.Find(id);
            db.Productos.Remove(tblProductos);
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
