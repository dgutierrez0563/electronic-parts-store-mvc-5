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
        public ActionResult TarjetaVideo2GB()
        {
            return View(_entidad.viewTarjetaVideo2GB());
        }
        public ActionResult TarjetaVideo3GB()
        {
            return View(_entidad.viewTarjetaVideo3GB());
        }
        public ActionResult TarjetaVideo4GB()
        {
            return View(_entidad.viewTarjetaVideo4GB());
        }
        public ActionResult TarjetaVideo8GB()
        {
            return View(_entidad.viewTarjetaVideo8GB());
        }
        public ActionResult TarjetaVideoAsus()
        {
            return View(_entidad.viewTarjetaVideoAsus());
        }
        public ActionResult TarjetaVideoMSI()
        {
            return View(_entidad.viewTarjetaVideoMSI());
        }
        public ActionResult TarjetaVideoZotac()
        {
            return View(_entidad.viewTarjetaVideoZotac());
        }
        public ActionResult TarjetaMdreAMD()
        {
            return View(_entidad.viewTarjetaMadreAMD());
        }
        public ActionResult TarjetaMdreIntel()
        {
            return View(_entidad.viewTarjetaMadreIntel());
        }
        public ActionResult TarjetaMdreAsus()
        {
            return View(_entidad.viewTarjetaMadreAsus());
        }
        public ActionResult TarjetaMdreGigabyte()
        {
            return View(_entidad.viewTarjetaMadreGigabyte());
        }
        public ActionResult TarjetaMdreMSI()
        {
            return View(_entidad.viewTarjetaMadreMSI());
        }
        public ActionResult Ram8GB()
        {
            return View(_entidad.viewRam8GB());
        }
        public ActionResult Ram16GB()
        {
            return View(_entidad.viewRam16GB());
        }
        public ActionResult PerifericosCooler()
        {
            return View(_entidad.viewPerifericosCooler());
        }
        public ActionResult PerifericosEnfriamientoLiquido()
        {
            return View(_entidad.viewPerifericosEnfriamientoLiquido());
        }
        public ActionResult PerifericosTeclado()
        {
            return View(_entidad.viewPerifericosTeclado());
        }
        public ActionResult AccesoriosVentilador()
        {
            return View(_entidad.viewAccesoriosVentilador());
        }
        public ActionResult GamingAMD()
        {
            return View(_entidad.GamingAMD());
        }
        public ActionResult GamingIntel()
        {
            return View(_entidad.GamingIntel());
        }
        public ActionResult OfficeAMD()
        {
            return View(_entidad.OfficeAMD());
        }
        public ActionResult OfficeIntel()
        {
            return View(_entidad.OfficeIntel());
        }
    }
}