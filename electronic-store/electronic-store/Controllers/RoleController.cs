using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using electronic_store.Models;
using electronic_store.DataModel;
//using electronic_store.ModelDO;

namespace electronic_store.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class RoleController : Controller
    {
        /// <summary>
        /// _contex for Controller
        /// </summary>
        ApplicationDbContext _context;

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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// GET: Role/Create
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        /// <summary>
        /// View Profile User
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult ProfileRoles()
        {
            electronic_sotore_Entities _entidad = new electronic_sotore_Entities();
            return View(_entidad.ProfileRoleUser());
        }
    }
}