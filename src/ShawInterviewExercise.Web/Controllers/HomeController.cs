using System.Web.Mvc;
using ShawInterviewExercise.Web.Routing;

namespace ShawInterviewExercise.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return this.Redirect(ShowRouter.Index(this.Url));
		}
	}
}
