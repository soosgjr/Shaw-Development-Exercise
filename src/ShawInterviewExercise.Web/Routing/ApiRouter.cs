using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawInterviewExercise.Web.Routing
{
	public static class ApiRouter
	{
		private static string ApiUrlValue = null;

		public static string ApiUrl
		{
			get
			{
				if (ApiUrlValue == null)
				{
					ApiUrlValue = ConfigurationManager.AppSettings["ApiUrl"];
				}
				return ApiUrlValue;
			}
		}
	}
}
