﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RestaurantAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{restaurantId}/{action}/{id}",
                defaults: new { restaurantId = RouteParameter.Optional, action = RouteParameter.Optional, id = RouteParameter.Optional}
            );
        }
    }
}
