using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Twix.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CreateTweetAPI",
                routeTemplate: "api/v1/createtweet/{id}",
                defaults: new { controller = "apiCreateTweet", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "UserAPI",
                routeTemplate: "api/v1/user/{id}",
                defaults: new {controller = "apiUser", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "FollowerAPI",
                routeTemplate: "api/v1/follow/{id}",
                defaults: new { controller = "apiFollower", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "LoginAPI",
                routeTemplate: "api/v1/login/{id}",
                defaults: new {controller = "apiLogin", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TweetAPI",
                routeTemplate: "api/v1/tweets/{id}",
                defaults: new { controller = "apiTweet", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
