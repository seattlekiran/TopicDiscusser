using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net;
using TopicDiscusser.Models;
using System.Web.Http.Routing;
using TopicDiscusser.MessageHandlers;

namespace TopicDiscusser
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                    name: "DefaultApiWithExtension2",
                    routeTemplate: "api/{controller}/{id}.{ext}"
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithExtension1",
                routeTemplate: "api/{controller}.{ext}");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "application/xml");
            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");

            config.MessageHandlers.Add(new LinkGenerationHandler());
        }
    }
}
