using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home/Restaurant/{id}
        public ActionResult Restaurant(int id)
        {
            ViewBag.RestaurantId = id;
            return View();
        }

    }
}