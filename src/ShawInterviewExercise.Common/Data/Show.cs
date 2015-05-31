using System.ComponentModel.DataAnnotations;

namespace ShawInterviewExercise.Common.Data
{
	public class Show
	{
		public int Id { get; set; }

		public string Slug { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		public string Filename { get; set; }
	}
}
