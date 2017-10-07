using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantAPI.Models
{
    public class DocumentItem
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string ExampleRequest { get; set; }
        public string Information { get; set; }
    }

}