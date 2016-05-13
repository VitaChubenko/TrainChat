using System.Web.Mvc;
using System.Web.Routing;

namespace TrainChat.Web.Api
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TrainChat.Web.Api.Controllers" }
			);

            routes.MapRoute(
                name: "Rooms",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Course", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TrainChat.Web.Api.Controllers" }
            );
        }
	}
}
