using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShawInterviewExercise.Common.Data;
using ShawInterviewExercise.Web.Net;
using ShawInterviewExercise.Web.Routing;

namespace ShawInterviewExercise.Web.Controllers
{
	public class ShowController : Controller
	{
		private IShowApiClient ShowApiClient;

		public ShowController()
			: this(null)
		{
			return;
		}

		public ShowController(IShowApiClient apiClient)
		{
			this.ShowApiClient = apiClient ?? new ApiClient();
		}

		public async Task<ActionResult> Index()
		{
			var shows = await this.ShowApiClient.GetAllShows();
			return this.View(shows);
		}

		public async Task<ActionResult> Details(int id, string slug)
		{
			try
			{
				var show = await this.ShowApiClient.GetShow(id);

				if (slug != show.Slug)
				{
					return this.Redirect(ShowRouter.Details(this.Url, id, show.Slug));
				}

				return this.View(show);
			}
			catch (InvalidKeyException)
			{
				return this.HttpNotFound();
			}
		}
	}
}
