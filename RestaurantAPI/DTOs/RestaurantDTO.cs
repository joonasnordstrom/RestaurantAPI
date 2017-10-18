using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.DTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RestaurantID { get; set; }
    }
}