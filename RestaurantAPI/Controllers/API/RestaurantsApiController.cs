using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantAPI.Controllers.API
{
    public class RestaurantsApiController : ApiController
    {
        private ApplicationDbContext _context;
        public RestaurantsApiController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult Restaurants()
        {
            var viewModel = _context.Restaurants.ToList();
            return Ok(viewModel);
        }

        [HttpGet]
        public IHttpActionResult Restaurants(int id)
        {
            var restaurant = _context.Restaurants.SingleOrDefault(r => r.ID == id);
            if (restaurant != null)
                return Ok(restaurant);

            return NotFound();
        }

        [HttpGet]
        public IHttpActionResult Restaurants(string name)
        {
            var restaurant = _context.Restaurants.SingleOrDefault(r => r.Name == name);
            if (restaurant != null)
                return Ok(restaurant);

            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var restaurantToDelete = _context.Restaurants.ToList().SingleOrDefault(r => r.ID == id);

            if (restaurantToDelete != null)
            {
                _context.Restaurants.Remove(restaurantToDelete);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
                

        }
         
    }
}
