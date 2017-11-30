using electronic_store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace electronic_store.Controllers
{
    public class ShopCarsController : Controller
    {
        /// <summary>
        /// Call Context
        /// </summary>
        private Contexto db = new Contexto();

        // GET: ShopCars
        /// <summary>
        /// Index Car List
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<ShopCar> shopcar = (List<ShopCar>)Session["list"];
            if (shopcar != null)
            {
                return View(shopcar.ToList());
            }
            else {
                //return RedirectToAction("Index", "Home");
                return View();
            }            
        }
        /// <summary>
        /// Method for add to car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddToCar(int id)
        {

            if (Session["list"] == null)
            {
                List<ShopCar> shopcar = new List<ShopCar>();
                shopcar.Add(new ShopCar(db.Productoes.Find(id), 1));
                Session["list"] = shopcar;
                //id = 0;
            }
            else
            {
                List<ShopCar> shopcar = (List<ShopCar>)Session["list"];
                int auxiliar = getIDProducto(id);
                if (auxiliar == -1)
                {
                    shopcar.Add(new ShopCar(db.Productoes.Find(id), 1));
                    //id = 0;
                }
                else
                {
                    shopcar[auxiliar].Cantidad++;
                    Session["list"] = shopcar;
                }                
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Delete ID of Products List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            List<ShopCar> shopcar = (List<ShopCar>)Session["list"];
            shopcar.RemoveAt(getIDProducto(id));
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Method for Purchase
        /// </summary>
        /// <returns></returns>
        public ActionResult FinishPurchase()
        {
            if (User.Identity.IsAuthenticated)
            {
                string username = "";
                List<ShopCar> shopcar = (List<ShopCar>)Session["list"];
                if (shopcar != null && shopcar.Count > 0)
                {
                    Factura newFactura = new Factura();
                    username = User.Identity.Name;
                    newFactura.Cliente = username;
                    newFactura.TotalFactura = shopcar.Sum(x => x.Producto.Precio * x.Cantidad);
                    newFactura.FechaCreado = DateTime.Now;
                    newFactura.FechaActualizado = DateTime.Now;

                    db.Facturas.Add(newFactura);
                    db.SaveChanges();

                    DetalleFactura newDetail = new DetalleFactura();
                    foreach (var item in Session["list"] as List<ShopCar>)
                    {
                        newDetail.FacturaID = newFactura.IDFactura;
                        newDetail.ProductoID = item.Producto.IDProducto;
                        newDetail.Cantidad = item.Cantidad;
                        newDetail.PrecioProducto = item.Producto.Precio;
                        newDetail.FechaCreado = DateTime.Now;
                        newDetail.FechaActualizado = DateTime.Now;
                        db.DetalleFacturas.Add(newDetail);
                        db.SaveChanges();

                        Producto assistant = new Producto();
                        assistant.IDProducto = item.Producto.IDProducto;
                        assistant.Nombre = item.Producto.Nombre;
                        assistant.Precio = item.Producto.Precio;
                        assistant.IDCategoria = item.Producto.IDCategoria;
                        assistant.IDProveedor = item.Producto.IDProveedor;
                        assistant.Stock = item.Producto.Stock - item.Cantidad;
                        assistant.FechaCreado = item.Producto.FechaCreado;
                        assistant.FechaActualizado = item.Producto.FechaActualizado;

                        db.Entry(assistant).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    shopcar.Clear();
                }
                return View();
            }
            else {
                return RedirectToAction("PurchaseIncomple", "ShopCars");
            }
        }
        /// <summary>
        /// Search Position ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int getIDProducto(int id)
        {
            //Call List of Car
            List<ShopCar> shopcar = (List<ShopCar>)Session["list"];
            for (int i = 0; i < shopcar.Count; i++)
            {
                if (shopcar[i].Producto.IDProducto == id)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Method Error Purchase Incomplete
        /// </summary>
        /// <returns></returns>
        public ActionResult PurchaseIncomple() {
            return View();
        }
    }
}