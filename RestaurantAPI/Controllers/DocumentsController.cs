using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantAPI.Models;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestaurantAPI.ViewModels;
namespace RestaurantAPI.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        public ActionResult Index()
        {
            var documentItems = new List<DocumentItem>
            {
                new DocumentItem {Id = 0, Title="Testi",Information="jojojojojojojojökjadfalöfhjasökfjasf a faökfja sökfjas fksjfsöafjsakfjsaöfksjafök ahjsöfjasöfksajföaskfojooooo", ExampleRequest="dfsafsegjöskgj aöäfgjkaöfjaökfjaöfjaöskfjsalf\n öajföakfjsaöklfja aöfjasökfjasökfj"},
                new DocumentItem {Id = 1, Title = "Toinen testi", Information="käytetään testauksessa", ExampleRequest = "Banaani perkele paska jumalauta zxxxxxxxxxxxxxxx" },
                new DocumentItem {Id = 2, Title = "Kolmas testi", Information="Joojoo", ExampleRequest = "" }
            };

            var viewModel = new DocumentViewModel
            {
                DocumentItems = documentItems

            };
            
            return View(viewModel);
    
        }
    }
}
