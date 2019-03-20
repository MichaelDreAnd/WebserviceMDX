﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebServicesMDX
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{year}/{month}/{day}",
                defaults: new { year = RouteParameter.Optional, month = RouteParameter.Optional, day = RouteParameter.Optional
                }
            );
        }
    }
}
