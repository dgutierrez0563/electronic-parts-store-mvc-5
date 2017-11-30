using electronic_store.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Security;

namespace electronic_store.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //string userID = User.Identity.Name;

            //if (User.Identity.IsAuthenticated==Roles.GetRolesForUser(userID))
            //{

            //    if (Roles.IsUserInRole(userID, "Administrator"))
            //    {
            //        return RedirectToAction("LayoutAdmin", "Home");
            //    }
            //    else
            //    {
            //        return View();
            //    }
            //}
            //else {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult LayoutAdmin()
        {
            return View();
        }
    }
}