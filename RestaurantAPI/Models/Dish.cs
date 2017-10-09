namespace RestaurantAPI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Dish : DbContext
    {
        // Your context has been configured to use a 'Dish' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RestaurantAPI.Models.Dish' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Dish' 
        // connection string in the application configuration file.
        public Dish()
            : base("Dish")
        {
        }

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

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}