using System.Text;
using System.Text.RegularExpressions;

namespace ShawInterviewExercise.Common.Data
{
	public static class Slugifier
	{
		public static string Slugify(string text)
		{
			string result = text.ToLowerInvariant();
			byte[] unaccentedBytes = Encoding.GetEncoding("Cyrillic").GetBytes(result);
			result = Encoding.ASCII.GetString(unaccentedBytes);
			result = Regex.Replace(result, @"[\s_]", "-", RegexOptions.Compiled);
			result = Regex.Replace(result, @"[^a-z0-9-]", "", RegexOptions.Compiled);
			result = result.Trim('-', '_');
			result = Regex.Replace(result, @"([-_]){2,}", "$1", RegexOptions.Compiled);
			return result;
		}
	}
}
