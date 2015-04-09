using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Swashbuckle.Application;

namespace PAF.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(name: "AddressByPostcode", routeTemplate: "{controller}/{action}/{postcode}");

           // config.Routes.MapHttpRoute(name: "AddressByBuilding", routeTemplate: "{controller}/{action}/{buildingName}/{buildingNumber}/{postcode}");

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "{controller}/{action}",
                defaults: new { action = "Get" }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new XmlMediaTypeFormatter());
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());
        }
    }
}
