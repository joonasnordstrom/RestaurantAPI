using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantAPI.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // GET: Home/Restaurant/{id}
        public ActionResult Restaurant(int id)
        {
            var dishesViewModel = _context.Dishes.ToList().Where(r => r.RestaurantID == id);
            ViewBag.RestaurantId = id;

            return View(dishesViewModel);
        }

    }
}