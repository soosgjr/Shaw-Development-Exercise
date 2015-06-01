using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShawInterviewExercise.Common.Data;
using ShawInterviewExercise.Web.Net;
using ShawInterviewExercise.Web.Routing;

namespace ShawInterviewExercise.Web.Controllers
{
	public class ShowAdminController : Controller
	{
		private IShowApiClient ShowApiClient;

		public ShowAdminController()
			: this(null)
		{
			return;
		}

		public ShowAdminController(IShowApiClient apiClient)
		{
			this.ShowApiClient = apiClient ?? new ApiClient();
		}

		public async Task<ActionResult> Index()
		{
			var shows = await this.ShowApiClient.GetAllShows();
			return this.View(shows);
		}

		public ActionResult Create()
		{
			return this.View(new Show());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Show model)
		{
			if (this.ModelState.IsValid)
			{
				await this.ShowApiClient.CreateShow(model);
				return this.Redirect(ShowAdminRouter.Index(this.Url));
			}
			else
			{
				return this.View(model);
			}
		}

		public async Task<ActionResult> Update(int id)
		{
			try
			{
				Show show = await this.ShowApiClient.GetShow(id);
				return this.View(show);
			}
			catch (InvalidKeyException)
			{
				return this.HttpNotFound();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Update(Show model)
		{
			if (this.ModelState.IsValid)
			{
				await this.ShowApiClient.UpdateShow(model);
				return this.Redirect(ShowAdminRouter.Index(this.Url));
			}
			else
			{
				return this.View(model);
			}
		}

		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				Show show = await this.ShowApiClient.GetShow(id);
				return this.View(show);
			}
			catch (InvalidKeyException)
			{
				return this.HttpNotFound();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(Show model)
		{
			try
			{
				await this.ShowApiClient.DeleteShow(model.Id);
				return this.Redirect(ShowAdminRouter.Index(this.Url));
			}
			catch (InvalidKeyException)
			{
				return this.HttpNotFound();
			}
		}
	}
}
