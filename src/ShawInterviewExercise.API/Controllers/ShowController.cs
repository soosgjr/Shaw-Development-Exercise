using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
			this.ShowDal = dal ?? new Dal();
		}

		public IEnumerable<Show> Get()
		{
			return this.ShowDal.GetAllShows();
		}

		public Show Get(int id)
		{
			Show show = this.ShowDal.GetShowById(id);

			if (show == null)
			{
				var message = new HttpResponseMessage(HttpStatusCode.NotFound);
				throw new HttpResponseException(message);
			}

			return show;
		}

		public void Post(Show show)
		{
			try
			{
				this.ShowDal.CreateShow(show);
			}
			catch (DuplicateKeyException)
			{
				var message = new HttpResponseMessage(HttpStatusCode.Conflict);
				throw new HttpResponseException(message);
			}
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
			catch (DuplicateKeyException)
			{
				var message = new HttpResponseMessage(HttpStatusCode.Conflict);
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
