using System.Collections.Generic;
using System.Threading.Tasks;
using ShawInterviewExercise.Common.Data;

namespace ShawInterviewExercise.Web.Net
{
	public interface IShowApiClient
	{
		void CreateShow(Show show);

		Task<IEnumerable<Show>> GetAllShows();

		Task<Show> GetShow(int id);

		void UpdateShow(Show show);

		void DeleteShow(int id);
	}
}
