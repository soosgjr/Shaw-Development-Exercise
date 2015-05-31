using System.Collections.Generic;
using System.Threading.Tasks;
using ShawInterviewExercise.Common.Data;

namespace ShawInterviewExercise.Web.Net
{
	public interface IShowApiClient
	{
		Task CreateShow(Show show);

		Task<IEnumerable<Show>> GetAllShows();

		Task<Show> GetShow(int id);

		Task UpdateShow(Show show);

		Task DeleteShow(int id);
	}
}
