using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShawInterviewExercise.Web.Routing
{
	public static class ShowAdminRouter
	{
		public static class RouteNames
		{
			public const string Index = "ShowAdmin.Index";
			public const string Create = "ShowAdmin.Create";
			public const string Update = "ShowAdmin.Update";
			public const string Delete = "ShowAdmin.Delete";
		}

		public static string Index(UrlHelper url)
		{
			return url.RouteUrl(RouteNames.Index);
		}

		public static string Create(UrlHelper url)
		{
			return url.RouteUrl(RouteNames.Create);
		}

		public static string Update(UrlHelper url, int id)
		{
			return url.RouteUrl(RouteNames.Update, new { id = id });
		}

		public static string Delete(UrlHelper url, int id)
		{
			return url.RouteUrl(RouteNames.Delete, new { id = id });
		}
	}
}
