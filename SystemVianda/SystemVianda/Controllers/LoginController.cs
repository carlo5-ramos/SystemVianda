using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SystemVianda.Models;

namespace SystemVianda.Controllers
{
    public class LoginController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Account

        public ActionResult IniciarSesion()
        {
            ViewBag.Bandera = false;
            return View();
        }
        [HttpPost]
        public ActionResult IniciarSesion(string TexUser, string TexPass)
        {
            //Aqui Encripto La Contraseña
            string Pass;
            Pass = Encriptar(TexPass);
            //Fin De Encriptamiento
            var User = (from x in db.Usuarios
                        where x.Usuario.Equals(TexUser) && x.Password.Equals(Pass)
                        select x).FirstOrDefault();



            if (User == null)
            {
                ViewBag.Bandera = true;
                ViewBag.Error = "El Usuario O Contraseña Son Incorrectas";
                return View();

            }
            else
            {
                //Validacion De Usuarios Y Contraseñas
                Session["IdUsuarios"] = User.IdUsuario;
                Session["Nombre"] = User.Usuario;
                Session["Rol"] = User.Roles.Rol;
                return RedirectToAction("Index", "Roles");
            }

        }
        public ActionResult Salir()
        {
            Session.Abandon();
            return View("IniciarSesion");
        }
        //Encriptar Contraseña
        public string Encriptar(string Pass)
        {
            SHA1 Sha1 = new SHA1CryptoServiceProvider();
            Byte[] Hash, InsertarByte;
            InsertarByte = (new UnicodeEncoding()).GetBytes(Pass);
            Hash = Sha1.ComputeHash(InsertarByte);

            return Convert.ToBase64String(Hash);
        }

    }
}

