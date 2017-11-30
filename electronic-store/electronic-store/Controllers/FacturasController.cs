using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using electronic_store.Models;
using electronic_store.DataModel;
using System;

namespace electronic_store.Controllers
{
    public class FacturasController : Controller
    {
        private electronic_sotore_Entities _entidad = new electronic_sotore_Entities();
        private Contexto db = new Contexto();

        // GET: Facturas
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Facturas.ToList());
        }

        // GET: Facturas/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "IDFactura,Cliente,TotalFactura,FechaCreado,FechaActualizado")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factura);
        }

        // GET: Facturas/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "IDFactura,Cliente,TotalFactura,FechaCreado,FechaActualizado")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factura);
        }

        // GET: Facturas/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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

        public ActionResult viewInvoiceUser()
        {

            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;

                var auxFilter = (from f in db.Facturas
                                 where f.Cliente.Equals(username)
                                 orderby f.IDFactura ascending
                                 select f);

                return View(auxFilter.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //return View();
        }

        public ActionResult viewDatailsInvoice(int id)
        {
            return View(_entidad.viewDetailsInvoice(id));
        }

        public ActionResult ErrorInvoice()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AllFacturas()
        {
            var auxFilter = (from f in db.Facturas
                             orderby f.FechaCreado ascending
                             select f);

            return View(auxFilter.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AllFacturas(string dateInitial, string dateFinal)
        {
            if (dateInitial != "" && dateFinal != "")
            {
                DateTime? date1 = Convert.ToDateTime(dateInitial);
                DateTime? date2 = Convert.ToDateTime(dateFinal);
                if (date2 > date1)
                {
                    var auxFilter = (from f in db.Facturas
                                     where (f.FechaCreado >= @date1)
                                     where (f.FechaCreado <= @date2)
                                     orderby f.FechaCreado ascending
                                     select f);

                    return View(auxFilter.ToList());
                }
                else
                {
                    return RedirectToAction("ErrorInvoice");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
