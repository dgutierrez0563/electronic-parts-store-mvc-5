using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using project.Models;
using System;

namespace project.Controllers
{
    public class ProductoesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Productoes
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categorias).Include(p => p.Proveedors);
            return View(productos.ToList());
        }

        public ActionResult List() {
            var productos = db.Productos.ToList();
            return View(productos);
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nombre");
            ViewBag.IDProveedor = new SelectList(db.Proveedors, "IDProveedor", "Nombre");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProducto,Nombre,Precio,IDCategoria,IDProveedor,Stock,FechaCreado,FechaActualizado")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.FechaCreado = DateTime.Now;
                producto.FechaActualizado = DateTime.Now;
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nombre", producto.IDCategoria);
            ViewBag.IDProveedor = new SelectList(db.Proveedors, "IDProveedor", "Nombre", producto.IDProveedor);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nombre", producto.IDCategoria);
            ViewBag.IDProveedor = new SelectList(db.Proveedors, "IDProveedor", "Nombre", producto.IDProveedor);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProducto,Nombre,Precio,IDCategoria,IDProveedor,Stock,FechaCreado,FechaActualizado")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.FechaActualizado = DateTime.Now;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Nombre", producto.IDCategoria);
            ViewBag.IDProveedor = new SelectList(db.Proveedors, "IDProveedor", "Nombre", producto.IDProveedor);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
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
