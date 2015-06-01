using System.Web.Mvc;

namespace ShawInterviewExercise.Web.Routing
{
	public class HomeRouter
	{
		public static class RouteNames
		{
			public const string Index = "Home.Index";
			public const string Sitemap = "Home.SiteMap";
		}

		public static string Index(UrlHelper url)
		{
			return url.RouteUrl(RouteNames.Index);
		}

		public static string Sitemap(UrlHelper url)
		{
			return url.RouteUrl(RouteNames.Sitemap);
		}
	}
}
