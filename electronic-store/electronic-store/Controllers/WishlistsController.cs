using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using electronic_store.Models;
using System;
using electronic_store.DataModel;

namespace electronic_store.Controllers
{
    public class WishlistsController : Controller
    {
        private Contexto db = new Contexto();
        private electronic_sotore_Entities _entidad = new electronic_sotore_Entities();

        // GET: Wishlists
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Wishlists.ToList());
        }

        // GET: Wishlists/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist wishlist = db.Wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
        }

        // GET: Wishlists/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wishlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "IDWishlist,UserName,ProductoID,FechaCreado,FechaActualizado")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                db.Wishlists.Add(wishlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wishlist);
        }

        // GET: Wishlists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist wishlist = db.Wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "IDWishlist,UserName,ProductoID,FechaCreado,FechaActualizado")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wishlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wishlist);
        }

        // GET: Wishlists/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist wishlist = db.Wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Wishlist wishlist = db.Wishlists.Find(id);
            db.Wishlists.Remove(wishlist);
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

        public ActionResult WishListUser()
        {

            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;

                var auxFilter = (from f in db.Wishlists
                                 where f.UserName.Equals(username)
                                 orderby f.IDWishlist ascending
                                 select f);

                return View(auxFilter.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CreateAt(int id)
        {
            //Wishlist newWish = new Wishlist();
            //int idProducto = Wishlist.db.Wishlists.Find(id);

            if (User.Identity.IsAuthenticated)
            {
                //Wishlist newWish = new Wishlist();

                //var auxFilter = (from f in db.Wishlists
                //                 where f.ProductoID.Equals(id)
                //                 select f);

                Wishlist newWish = new Wishlist();
                string username = User.Identity.Name;
                newWish.UserName = username;
                newWish.ProductoID = id;
                newWish.FechaCreado = DateTime.Now;
                newWish.FechaActualizado = DateTime.Now;

                db.Wishlists.Add(newWish);
                db.SaveChanges();

                return RedirectToAction("viewWishlist");

                //Wishlist newWish = new Wishlist();
                //string username = User.Identity.Name;
                //newWish.UserName = username;
                //newWish.ProductoID = id;
                //newWish.FechaCreado = DateTime.Now;
                //newWish.FechaActualizado = DateTime.Now;

                //db.Wishlists.Add(newWish);
                //db.SaveChanges();

                //return RedirectToAction("WishListUser");

            }
            else
            {
                return RedirectToAction("WishlistIncomplete");
            }
        }

        public ActionResult DeleteAt(int id)
        {

            Wishlist wishlist = db.Wishlists.Find(id);
            db.Wishlists.Remove(wishlist);
            db.SaveChanges();
            return RedirectToAction("viewWishlist");
        }

        public ActionResult WishlistIncomplete()
        {
            return View();
        }

        public ActionResult viewWishlist() {
            if (User.Identity.IsAuthenticated)
            {
                string user = User.Identity.Name;
                return View(_entidad.viewWishlistUser(user));
            }
            else {
                return RedirectToAction("WishlistIncomplete");
            }
            
        }
    }
}
