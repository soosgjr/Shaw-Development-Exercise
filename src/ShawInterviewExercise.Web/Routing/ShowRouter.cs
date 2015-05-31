using System.Web.Mvc;

namespace ShawInterviewExercise.Web.Routing
{
	public class ShowRouter
	{
		private const string ImageBaseUrl = "http://localhost/ShawInterviewExercise.Api/Content/images/shows/";

		public static class RouteNames
		{
			public const string Index = "Show.Index";
			public const string Details = "Show.Details";
		}

		public static string Index(UrlHelper url)
		{
			return url.RouteUrl(RouteNames.Index);
		}

		public static string Details(UrlHelper url, int id, string slug)
		{
			return url.RouteUrl(RouteNames.Details, new { id = id, slug = slug });
		}

		public static string Image(UrlHelper url, string filename)
		{
			return url.Content(ImageBaseUrl + filename);
		}
	}
}
