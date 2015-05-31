using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using ShawInterviewExercise.Common.Data;
using ShawInterviewExercise.Web.Routing;

namespace ShawInterviewExercise.Web.Net
{
	public class ApiClient : IShowApiClient
	{
		public async void CreateShow(Show show)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Show>> GetAllShows()
		{
			return await this.RequestData<IEnumerable<Show>>(ApiRouter.Show.GetAllShow);
		}

		public async Task<Show> GetShow(int id)
		{
			return await this.RequestData<Show>(String.Format(ApiRouter.Show.GetShow, id.ToString()));
		}

		public async void UpdateShow(Show show)
		{
			throw new NotImplementedException();
		}

		public async void DeleteShow(int id)
		{
			throw new NotImplementedException();
		}

		private async Task<T> RequestData<T>(string url)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(ApiRouter.ApiUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsAsync<T>();
					return result;
				}
				else
				{
					switch (response.StatusCode)
					{
						case HttpStatusCode.Conflict:
							throw new DuplicateKeyException();

						case HttpStatusCode.NotFound:
							throw new InvalidKeyException();

						default:
							throw new HttpException((int)response.StatusCode, response.ReasonPhrase);
					}
				}

				//return JsonConvert.DeserializeObject<T>(response);
			}
		}
	}
}
