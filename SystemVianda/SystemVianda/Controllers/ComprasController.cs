using System;
using System.Linq;
using System.Net;
using SystemVianda.Models;
using System.Web.Mvc;

namespace SystemVianda.Controllers
{
    public class ComprasController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Compras

        public ActionResult Index()
        {
            ViewBag.IdProveedor = new SelectList(db.Proveedores, "IdProveedor", "Empresa");
            ViewBag.IdProducto = new SelectList(db.Productos.Where(x => x.Estado == true), "IdProducto", "Nombre");
            ViewBag.IdUnidadMedida = new SelectList(db.UnidadDeMedidas, "IdUnidadMedida", "Nombre");


            return View();
        }


        //creando la compra
        [HttpPost]
        public JsonResult CompraAjaxMethod(int IdProveedor, string Factura,  DateTime FechaCompra, string Des)
        {

            try
            {
                

                var ModeloCompra = new TblCompras()
                {
                    CodigoFactura = Factura,
                    IdUsuario = (int)Session["IdUsuario"],
                     
                    IdProveedor = IdProveedor,
                    FecCompra = Convert.ToDateTime(FechaCompra),
                    FechaRegistro = DateTime.Now.Date,
                    Estado = true,
                    Descripcion = Des
                };
                db.Compras.Add(ModeloCompra);
                db.SaveChanges();
                return Json(true);
             }
            catch
            {
                return Json(false);
            }
        }

        //accion para detalle de compra
        [HttpPost]
        public JsonResult DetalleCompraAjaxMethod(int CodigoP, string NombreP, double CantidadP, double PrecioP, double TacticoP, double MermaP, double TotalP)
        {
            try
            {
                var IdCompra = (from c in db.Compras
                                select c.IdCompra).Max();


                var DetalleCompra = new TblDetallesCompras()
                {
                    //PrecioCompra
                    //PesoFactura
                    //Cantidad
                    //SubTotal
                    //TacticoFactura
                    //Merma
                    //Descripcion
                   
                };
                //Aumento en el Stock
                var SelectProd = (from p in db.Productos
                                  where p.IdProducto == CodigoP
                                  select p).FirstOrDefault();
                SelectProd.Existencia = SelectProd.Existencia ;
                db.Entry(SelectProd).State = System.Data.Entity.EntityState.Modified;
                db.DetallesCompras.Add(DetalleCompra);
                db.SaveChanges();
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }

        //listado de compra
        public ActionResult Compras()
        {
            db.Compras.ToList();
            return View(db.Compras.ToList());
        }
        [HttpPost]
        public ActionResult Compras(DateTime FI, DateTime FF)
        {
            try
            {
                DateTime FM = FF.AddDays(1);



                var RegistrosCompras = (from t in db.Compras
                                        where (t.FecCompra >= FI && t.FecCompra <= FM)
                                        orderby t.IdCompra ascending
                                        select t).ToList();



                return View(RegistrosCompras);

            }
            catch (Exception)
            {

                throw;
            }
        }
        //ver compra 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Campos de Compra
            ViewBag.factura = (from c in db.Compras
                               where c.IdCompra == id
                               select c).ToList();
            //Nombre Proveedor
            var queryy = db.Compras.Where(z => z.IdCompra == id).FirstOrDefault().Proveedores.Contacto;
            ViewBag.pro = queryy;

            //Registro Detalle & Compra
            var Detalle = (from d in db.DetallesCompras
                           where d.IdCompra == id
                           select d).ToList();

          

            //Suma Total Detalle
            if (Detalle == null)
            {
                ViewBag.Total = 0;
            }
            else
            {
                ViewBag.Total = Detalle.Sum(x => x.SubTotal);
            }
            if (Detalle == null)
            {
                return HttpNotFound();
            }



            return View(Detalle.ToList());
        }
        public ActionResult EliminarCompra(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           
            ViewBag.factura = (from c in db.Compras
                               where c.IdCompra == id
                               select c).ToList();

            var queryy = db.Compras.Where(z => z.IdCompra == id).FirstOrDefault().Proveedores.Compras;

            ViewBag.pro = queryy;

            var Detalle = (from d in db.DetallesCompras
                           where d.IdCompra == id
                           select d).ToList();
            if (Detalle == null)
            {
                ViewBag.Total = 0;
            }
            else
            {
                ViewBag.Total = Detalle.Sum(x => x.SubTotal);
            }




          

            if (Detalle == null)
            {
                return HttpNotFound();
            }



            return View(Detalle.ToList());
        }
        [HttpPost, ActionName("EliminarCompra")]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int? id)
        {
            var selectDetalle = from x in db.DetallesCompras
                                where x.IdCompra == id
                                select x;
            foreach (var item in selectDetalle)
            {
                var idP = item.IdProducto;
                 double cant = item.Cantidad;
                var producto = db.Productos.Find(idP);
                producto.Existencia= Convert.ToInt32(producto.Existencia + cant);
                db.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();
                var eliminar = db.DetallesCompras.Find(item.IdDetallesC);
                db.DetallesCompras.Remove(eliminar);
                //db.SaveChanges();
            }
            var compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
            db.SaveChanges();


            return RedirectToAction("Compras/Details");
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDetallesCompras detalleCompra = db.DetallesCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }
       
        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var Detalle = (from d in db.DetallesCompras
                           where d.IdDetallesC == id
                           select d).FirstOrDefault();

            var idProducto = Detalle.IdProducto;
            var cantidad = Detalle.Cantidad;
            var actualizar = db.Productos.Find(idProducto);

            actualizar.Existencia = Convert.ToInt32(actualizar.Existencia - cantidad);
            db.Entry(actualizar).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();






            db.DetallesCompras.Remove(Detalle);
            db.SaveChanges();

            return RedirectToAction("Compras/Compras");
        }


    }
}
