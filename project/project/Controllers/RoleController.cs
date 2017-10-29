using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using project.Models;
using project.ModelDO;

namespace project.Controllers
{
    public class RoleController : Controller
    {
        /// <summary>
        /// _contex for Controller
        /// </summary>
        ApplicationDbContext _context;

        projectContextEntities _list = new projectContextEntities();
        
        /// <summary>
        /// DataObject from Data Base for View Profiles
        /// </summary>
        //Entities dbObjetc = new Entities();

        /// <summary>
        /// Initial Controller
        /// </summary>
        public RoleController() {
            _context = new ApplicationDbContext();
        }

        /// <summary>
        /// GET: Role
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// GET: Role/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// GET: Role/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        /// <summary>
        /// POST: Role/Create
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            try
            {
                _context.Roles.Add(Role);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProfileRoles()
        {

            return View(_list.ProfileRoleUser());
        }

        //// GET: Role/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Role/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Role/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Role/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}