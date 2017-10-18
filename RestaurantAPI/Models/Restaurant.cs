namespace RestaurantAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Restaurant
    {

        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}