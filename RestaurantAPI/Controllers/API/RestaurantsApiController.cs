using Newtonsoft.Json;
using RestaurantAPI.DTOs;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

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
        public IHttpActionResult GetRestaurants()
        {
            /*var viewModel = _context.Restaurants.ToList();
            return Ok(viewModel);*/
            var restaurants = from b in _context.Restaurants
                              select new RestaurantDTO()
                              {
                                  Id = b.ID,
                                  Name = b.Name,
                                  Address = b.Address,
                              };
            return Ok(restaurants);
        }

        [HttpGet]
        [Route("Restaurants/{id}")]
        public IHttpActionResult GetRestaurants(int id)
        {
            var restaurant = _context.Restaurants.SingleOrDefault(r => r.ID == id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);

        }

        [HttpGet]
        public IHttpActionResult Get(string name)
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

        [HttpPost]
        public IHttpActionResult Post(RestaurantDTO model)
        {
            Restaurant newRestaurant = new Restaurant();

            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid.");

            newRestaurant.Name = model.Name;
            newRestaurant.Address = model.Address;

            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges(); 

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Restaurant model)
        {
            var restaurant = _context.Restaurants.SingleOrDefault(r => r.ID == model.ID);

            if (restaurant == null)
                return NotFound();

            restaurant.Name = model.Name;
            restaurant.Address = model.Address;

            return Ok();
        }
       
         
    }
}
