using System.Collections.Generic;

namespace ShawInterviewExercise.Common.Data
{
	public interface IShowDal
	{
		void CreateShow(Show show);

		IEnumerable<Show> GetAllShows();

		Show GetShowById(int id);

		void UpdateShow(Show show);

		void DeleteShow(int id);
	}
}
