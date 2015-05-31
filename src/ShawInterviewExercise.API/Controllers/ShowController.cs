using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ShawInterviewExercise.Common.Data;

namespace ShawInterviewExercise.API.Controllers
{
	public class ShowController : ApiController
	{
		private IShowDal ShowDal { get; set; }

		public ShowController() : this(null) { }

		public ShowController(IShowDal dal = null)
		{
			this.ShowDal = dal ?? new XmlDal(HttpContext.Current.Server.MapPath("~/App_Data/shows.xml"));
		}

		public IEnumerable<Show> Get()
		{
			return this.ShowDal.ReadShows();
		}

		public Show Get(int id)
		{
			Show show = this.ShowDal.ReadShowById(id);

			if (show == null)
			{
				var message = new HttpResponseMessage(HttpStatusCode.NotFound);
				throw new HttpResponseException(message);
			}

			return show;
		}

		public void Post(Show show)
		{
			this.ShowDal.CreateShow(show);
		}

		public void Put(Show show)
		{
			try
			{
				this.ShowDal.UpdateShow(show);
			}
			catch (InvalidKeyException)
			{
				var message = new HttpResponseMessage(HttpStatusCode.NotFound);
				throw new HttpResponseException(message);
			}
		}

		public void Delete(int id)
		{
			try
			{
				this.ShowDal.DeleteShow(id);
			}
			catch (InvalidKeyException)
			{
				var message = new HttpResponseMessage(HttpStatusCode.NotFound);
				throw new HttpResponseException(message);
			}
		}
	}
}
