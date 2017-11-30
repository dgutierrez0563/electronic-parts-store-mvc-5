using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using electronic_store.Models;
using System;

namespace electronic_store.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AtributoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Atributoes
        public ActionResult Index()
        {
            var atributos = db.Atributos.Include(a => a.Productos);
            return View(atributos.ToList());
        }

        // GET: Atributoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atributo atributo = db.Atributos.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // GET: Atributoes/Create
        public ActionResult Create()
        {
            ViewBag.IDProducto = new SelectList(db.Productoes, "IDProducto", "Nombre");
            return View();
        }

        // POST: Atributoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAtributo,IDProducto,Nombre,Detalle,FechaCreado,FechaActualizado")] Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                atributo.FechaCreado = DateTime.Now;
                atributo.FechaActualizado = DateTime.Now;
                db.Atributos.Add(atributo);
                db.SaveChanges();
                return RedirectToAction("Create","Atributoes");
            }

            ViewBag.IDProducto = new SelectList(db.Productoes, "IDProducto", "Nombre", atributo.IDProducto);
            return View(atributo);
        }

        // GET: Atributoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atributo atributo = db.Atributos.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProducto = new SelectList(db.Productoes, "IDProducto", "Nombre", atributo.IDProducto);
            return View(atributo);
        }

        // POST: Atributoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAtributo,IDProducto,Nombre,Detalle,FechaCreado,FechaActualizado")] Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                atributo.FechaActualizado = DateTime.Now;
                db.Entry(atributo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProducto = new SelectList(db.Productoes, "IDProducto", "Nombre", atributo.IDProducto);
            return View(atributo);
        }

        // GET: Atributoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atributo atributo = db.Atributos.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // POST: Atributoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atributo atributo = db.Atributos.Find(id);
            db.Atributos.Remove(atributo);
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
