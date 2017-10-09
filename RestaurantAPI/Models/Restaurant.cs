namespace RestaurantAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Restaurant : DbContext
    {
        // Your context has been configured to use a 'Restaurant' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RestaurantAPI.Models.Restaurant' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Restaurant' 
        // connection string in the application configuration file.
        public Restaurant()
            : base("Restaurant")
        {
        }

        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Dish> Dishes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}