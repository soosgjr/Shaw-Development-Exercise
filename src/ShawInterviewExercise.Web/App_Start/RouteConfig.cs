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
				name: ShowAdminRouter.RouteNames.Index,
				url: "admin/shows",
				defaults: new { controller = "ShowAdmin", action = "Index" }
			);

			routes.MapRoute(
				name: ShowAdminRouter.RouteNames.Create,
				url: "admin/shows/new",
				defaults: new { controller = "ShowAdmin", action = "Create" }
			);

			routes.MapRoute(
				name: ShowAdminRouter.RouteNames.Update,
				url: "admin/shows/update/{id}",
				defaults: new { controller = "ShowAdmin", action = "Update" }
			);

			routes.MapRoute(
				name: ShowAdminRouter.RouteNames.Delete,
				url: "admin/shows/delete/{id}",
				defaults: new { controller = "ShowAdmin", action = "Delete" }
			);

			routes.MapRoute(
				name: HomeRouter.RouteNames.Index,
				url: "",
				defaults: new { controller = "Home", action = "Index" }
			);
		}
	}
}
