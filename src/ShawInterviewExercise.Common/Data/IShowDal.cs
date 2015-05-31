using System.Collections.Generic;

namespace ShawInterviewExercise.Common.Data
{
	public interface IShowDal
	{
		void CreateShow(Show show);

		IEnumerable<Show> ReadShows();

		Show ReadShowById(int id);

		void UpdateShow(Show show);

		void DeleteShow(int id);
	}
}
