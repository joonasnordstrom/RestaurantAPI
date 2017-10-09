using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class Restaurant
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IEnumerable<Dish> Menu { get; set; }
    }
}