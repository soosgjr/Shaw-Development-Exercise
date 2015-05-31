using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ShawInterviewExercise.Common.Data
{
	public class XmlDal : IDisposable, IShowDal
	{
		public string StorageFilepath;

		public XmlDal(string storageFilepath)
		{
			this.StorageFilepath = storageFilepath;
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

			List<Show> shows = this.LoadData();
			if (shows.Any())
			{
				show.Id = (from row in shows select row.Id).Max() + 1;
			}
			else
			{
				show.Id = 1;
			}
			show.Slug = Slugifier.Slugify(show.Name);

			var rng = new Random();
			var images = new string[] { "red.png", "green.png", "blue.png" };
			show.Filename = (from row in images orderby rng.NextDouble() select row).First();

			shows.Add(show);
			this.SaveData(shows);
		}

		public IEnumerable<Show> ReadShows()
		{
			return this.LoadData();
		}

		public Show ReadShowById(int id)
		{
			var shows = this.LoadData();
			return shows.FirstOrDefault(x => x.Id.Equals(id));
		}

		public void UpdateShow(Show show)
		{
			if (show == null)
			{
				throw new ArgumentNullException("show");
			}

			List<Show> shows = this.LoadData();
			IEnumerable<Show> matches = from row in shows where row.Id == show.Id select row;
			if (!matches.Any())
			{
				throw new InvalidKeyException();
			}

			Show match = matches.First();
			match.Name = show.Name;
			match.Slug = Slugifier.Slugify(show.Name);
			match.Description = show.Description;
			this.SaveData(shows);
		}

		public void DeleteShow(int id)
		{
			List<Show> shows = this.LoadData();
			IEnumerable<Show> matches = from row in shows where row.Id == id select row;
			if (!matches.Any())
			{
				throw new InvalidKeyException();
			}

			shows.Remove(matches.First());
			this.SaveData(shows);
		}

		private List<Show> LoadData()
		{
			if (File.Exists(this.StorageFilepath))
			{
				using (var fileStream = new FileStream(this.StorageFilepath, FileMode.Open))
				{
					var xml = new XmlSerializer(typeof(List<Show>));
					return (List<Show>)xml.Deserialize(fileStream);
				}
			}
			else
			{
				return new List<Show>();
			}
		}

		private void SaveData(IEnumerable<Show> data)
		{
			var serializer = new XmlSerializer(typeof(List<Show>));
			using (var stream = new FileStream(this.StorageFilepath, FileMode.Create))
			{
				serializer.Serialize(stream, data);
			}
		}
	}
}
