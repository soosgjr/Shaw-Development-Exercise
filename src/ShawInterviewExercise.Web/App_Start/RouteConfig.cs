using System.Web.Mvc;
using System.Web.Routing;
using ShawInterviewExercise.Web.Routing;

namespace ShawInterviewExercise.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: ShowRouter.RouteNames.Details,
				url: "shows/{id}/{slug}",
				defaults: new { controller = "Show", action = "Details", slug = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: ShowRouter.RouteNames.Index,
				url: "shows",
				defaults: new { controller = "Show", action = "Index" }
			);

			routes.MapRoute(
				name: HomeRouter.RouteNames.Index,
				url: "",
				defaults: new { controller = "Home", action = "Index" }
			);
		}
	}
}
