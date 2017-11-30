using electronic_store.DataModel;
using electronic_store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electronic_store.Controllers
{
    public class ConsultasController : Controller
    {

        Contexto db = new Contexto();
        electronic_sotore_Entities _entidad = new electronic_sotore_Entities();

        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Accesorios
        public ActionResult Accesorios()
        {
            return View(_entidad.viewAccesorios());
        }

        // GET: Clientes/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Producto producto = db.Productos.Find(id);
        //    if (producto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(producto);
        //}

        public ActionResult DetailsProduct(int? id)
        {
            return View(_entidad.viewDetailsProductos(id));
        }

        // GET: Accesorios
        public ActionResult Accesorios2()
        {
            return View(_entidad.viewAccesorios());
        }
        // GET: Case
        public ActionResult Case()
        {
            return View(_entidad.viewCase());
        }
        // GET: DiscoDuro
        public ActionResult DiscoDuro()
        {
            return View(_entidad.viewDiscoDuro());
        }

        public ActionResult FuentePoder()
        {
            return View(_entidad.viewFuentePoder());
        }

        public ActionResult Monitor()
        {
            return View(_entidad.viewMonitor());
        }

        public ActionResult Perifericos()
        {
            return View(_entidad.viewPerifericos());
        }

        public ActionResult Procesador()
        {
            return View(_entidad.viewProcesador());
        }

        public ActionResult ProcesadorAmd()
        {
            return View(_entidad.viewProcesadorAMD());
        }

        public ActionResult ProcesadorIntel()
        {
            return View(_entidad.viewProcesadorIntel());
        }

        public ActionResult Ram()
        {
            return View(_entidad.viewRam());
        }

        public ActionResult TarjetaMadre()
        {
            return View(_entidad.viewTarjetaMadre());
        }

        public ActionResult TarjetaVideo()
        {
            return View(_entidad.viewTarjetaVideo());
        }
    }
}