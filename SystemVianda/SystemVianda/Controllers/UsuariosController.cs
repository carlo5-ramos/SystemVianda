using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SystemVianda.Models;

namespace SystemVianda.Controllers
{
    public class UsuariosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(t => t.Empleado).Include(t => t.Roles);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre");
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Password,ConfirmPassword,Estado,IdEmpleado,IdRol")] TblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                tblUsuarios.Password = Encriptar(tblUsuarios.Password);
                tblUsuarios.ConfirmPassword = Encriptar(tblUsuarios.ConfirmPassword);
                db.Usuarios.Add(tblUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Password,ConfirmPassword,Estado,IdEmpleado,IdRol")] TblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {

                tblUsuarios.ConfirmPassword = tblUsuarios.Password;
                db.Entry(tblUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "Nombre", tblUsuarios.IdEmpleado);
            ViewBag.IdRol = new SelectList(db.Roles, "IdRol", "Rol", tblUsuarios.IdRol);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblUsuarios tblUsuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(tblUsuarios);
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
        public ActionResult NuevaPass(int id)
        {
            var Usuario = db.Usuarios.Find(id);
            return View(Usuario);
        }

        [HttpPost]
        public ActionResult NuevaPass(int txtId, string txtPassActual, string txtPass, string confimarPass)
        {
            try
            {
                var Actualizar = db.Usuarios.Find(txtId);
                if (Actualizar.Password == Encriptar(txtPassActual))
                {
                    Actualizar.Password = Encriptar(txtPass);
                    Actualizar.ConfirmPassword = Encriptar(confimarPass);
                    db.Entry(Actualizar).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var Usuario = db.Usuarios.Find(txtId);
                    return View(Usuario);
                }
            }
            catch
            {
                var data = db.Usuarios.Find(txtId);
                return View(data);

            }
        }

        public string Encriptar(string Pass)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            Byte[] Hash, InsertarByte;
            InsertarByte = (new UnicodeEncoding()).GetBytes(Pass);
            Hash = sha1.ComputeHash(InsertarByte);
            return Convert.ToBase64String(Hash);
        }
    }
}
