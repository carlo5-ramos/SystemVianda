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
    public class EmpleadosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Empleados
        public ActionResult Index()
        {
            return View(db.Empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpleados tblEmpleados = db.Empleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,Nombre,Apellido,Edad,Dui,Nit,Direccion,Telefono,Celular,Sexo,EstadoCivil,Cargo")] TblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(tblEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmpleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpleados tblEmpleados = db.Empleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,Nombre,Apellido,Edad,Dui,Nit,Direccion,Telefono,Celular,Sexo,EstadoCivil,Cargo")] TblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmpleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpleados tblEmpleados = db.Empleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEmpleados tblEmpleados = db.Empleados.Find(id);
            db.Empleados.Remove(tblEmpleados);
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
