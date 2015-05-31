using System;
using System.Collections.Generic;
using System.Linq;

namespace ShawInterviewExercise.Common.Data
{
	public class Dal : IDisposable, IShowDal
	{
		public List<Show> Shows { get; set; }

		public Dal()
		{
			this.Shows = this.GenerateDefaultData();
		}

		public void Dispose()
		{
			return;
		}

		public void CreateShow(Show show)
		{
			if (show == null)
			{
				throw new ArgumentNullException("show");
			}
			if ((from row in this.Shows where row.Id == show.Id select row).Any())
			{
				throw new DuplicateKeyException();
			}

			this.Shows.Add(show);
		}

		public IEnumerable<Show> GetAllShows()
		{
			return Shows;
		}

		public Show GetShowById(int id)
		{
			return this.Shows.FirstOrDefault(x => x.Id.Equals(id));
		}

		public void UpdateShow(Show show)
		{
			if (show == null)
			{
				throw new ArgumentNullException("show");
			}

			IEnumerable<Show> matches = from row in this.Shows where row.Id == show.Id select row;
			if (!matches.Any())
			{
				throw new InvalidKeyException();
			}

			this.Shows.Remove(matches.First());
			this.Shows.Add(show);
		}

		public void DeleteShow(int id)
		{
			throw new NotImplementedException();
		}

		private List<Show> GenerateDefaultData()
		{
			var shows = new List<Show>();

			shows.Add(
				new Show()
				{
					Id = 1,
					Slug = "pellentesque-vitae-nisi",
					Name = "Pellentesque Vitae Nisi",
					Description = "Praesent vitae erat eget elit placerat rhoncus ac non lectus.",
					Filename = "red.png",
				}
			);

			shows.Add(
				new Show()
				{
					Id = 2,
					Slug = "integer-commodo-tristique",
					Name = "Integer Commodo Tristique",
					Description = "Maecenas egestas lacus et est lobortis venenatis.",
					Filename = "green.png",
				}
			);

			shows.Add(
				new Show()
				{
					Id = 3,
					Slug = "aenean-at-volutpat",
					Name = "Aenean At Volutpat",
					Description = "Donec non quam ut felis ullamcorper fringilla nec in orci.",
					Filename = "blue.png",
				}
			);

			return shows;
		}
	}
}
