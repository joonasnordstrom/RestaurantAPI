using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class Dish
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string ImagePath { get; set; }

    }
}