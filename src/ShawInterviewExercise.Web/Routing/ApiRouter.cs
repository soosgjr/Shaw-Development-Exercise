using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawInterviewExercise.Web.Routing
{
	public static class ApiRouter
	{
		public static string ApiUrl
		{
			get
			{
				return "http://localhost/ShawInterviewExercise.Api/";
			}
		}

		public static class Show
		{
			public const string CreateShow = "api/show";
			public const string GetAllShow = "api/show";
			public const string GetShow = "api/show/{0}";
			public const string UpdateShow = "api/show";
			public const string DeleteShow = "api/show";
		}
	}
}
