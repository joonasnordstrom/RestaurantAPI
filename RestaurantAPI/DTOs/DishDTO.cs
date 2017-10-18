using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.DTOs
{
    public class DishDTO
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
       
    }
}