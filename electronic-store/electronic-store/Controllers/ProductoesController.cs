using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using electronic_store.Models;

namespace electronic_store.Controllers
{
    public class ProductoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Productoes
        public ActionResult Index()
        {
            var productos = db.Productoes.Include(p => p.Categorias).Include(p => p.Proveedors);
            return View(productos.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
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
                db.Productoes.Add(producto);
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
            Producto producto = db.Productoes.Find(id);
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
            Producto producto = db.Productoes.Find(id);
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
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
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

        public ActionResult List()
        {
            var productos = db.Productoes.ToList();
            return View(productos);

            //return View(db.Productoes.ToList().OrderBy(x => x.Nombre));
        }

        [HttpPost]
        public ActionResult List(string productName, string categoryName, double priceInitial = 0, double priceFinal = 0)
        {
            if (productName != "")
            {
                var auxFilter = (from f in db.Productoes
                                 where f.Nombre.StartsWith(productName)
                                 orderby f.Nombre ascending
                                 select f);

                return View(auxFilter.ToList());
            }

            if (categoryName != "")
            {
                var auxFilter = (from f in db.Productoes
                                 where f.Categorias.Nombre.StartsWith(categoryName)
                                 orderby f.Nombre ascending
                                 select f);

                return View(auxFilter.ToList());
            }

            if (priceInitial > 0 && priceFinal > 0 /*&& (priceFinal > priceInitial)*/)
            {
                if (priceFinal > priceInitial) {
                    var auxFilter = (from f in db.Productoes
                                     where (f.Precio >= @priceInitial)
                                     where (f.Precio <= @priceFinal)
                                     orderby f.Precio ascending
                                     select f);
                    return View(auxFilter.ToList());
                }
                else
                {
                    return View("NotFound");
                }
            }
            else
            {
                //return View(db.Productoes.OrderByDescending(f =>
                //f.Nombre).ToList());
                return RedirectToAction("List");
            }
        }

        public ActionResult NotFound() {
            return View();
        }

    }
}
