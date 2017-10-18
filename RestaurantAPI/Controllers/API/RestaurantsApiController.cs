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
        public IHttpActionResult Get()
        {
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
        [Route("api/restaurantsapi/{id}")]
        public IHttpActionResult GetRestaurants(int id)
        {
            var restaurant = _context.Restaurants.ToList().SingleOrDefault(r => r.ID == id);
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

        [System.Web.Mvc.ValidateAntiForgeryToken()]
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

        [HttpGet]
        [Route("api/RestaurantsApi/{restaurantId}/Dishes")]
        public IHttpActionResult GetDishes(int restaurantId)
        {
            var dishesInDb = _context.Dishes.ToList().Where(d => d.RestaurantID == restaurantId);
            if (!dishesInDb.Any())
                return NotFound();

            IEnumerable<DishDTO> dishes;
            dishes = from b in dishesInDb
              select new DishDTO()
              {
                  ID = b.ID,
                  Name = b.Name,
                  RestaurantID = restaurantId,
              };
            return Ok(dishes);
        }

        [System.Web.Mvc.ValidateAntiForgeryToken()]
        [HttpPost]
        [Route("api/RestaurantsApi/{restaurantId}/Dishes")]
        public IHttpActionResult AddDish(DishDTO model)
        {
            Dish newDish = new Dish();

            if (!ModelState.IsValid)
                return BadRequest("Model state is not valid.");
 
            newDish.Name = model.Name;
            newDish.RestaurantID = model.RestaurantID;
            newDish.Price = model.Price;

            _context.Dishes.Add(newDish);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/restaurantsApi/{restaurantID}/Dishes/{name}")]
        public IHttpActionResult GetDishByName(string name)
        {
        var dish = _context.Dishes.SingleOrDefault(r => r.Name == name);
            if (dish != null)
                return Ok(dish);

            return NotFound();
        }

        [HttpDelete]
        [Route("api/restaurantApi/{restaurantId}/Dishes/{id}")]
        public IHttpActionResult DeleteDish(int id)
        {
            var dishToDelete = _context.Restaurants.ToList().SingleOrDefault(r => r.ID == id);

            if (dishToDelete != null)
            {
                _context.Restaurants.Remove(dishToDelete);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }


    }
}
