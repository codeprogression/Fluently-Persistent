using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.FluentlyPersistent.Web.Bootstrap;
using NHibernate;

namespace CP.FluentlyPersistent.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            // NOTE: Only here to create db, cuz we don't have any other session impl.
            Container.GetInstance<ISessionFactory>(); 
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
