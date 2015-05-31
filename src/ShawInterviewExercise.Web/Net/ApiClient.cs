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
		public async Task CreateShow(Show show)
		{
			await this.Post("api/show", show);
		}

		public async Task<IEnumerable<Show>> GetAllShows()
		{
			return await this.Get<IEnumerable<Show>>("api/show");
		}

		public async Task<Show> GetShow(int id)
		{
			return await this.Get<Show>(String.Format("api/show/{0}", id.ToString()));
		}

		public async Task UpdateShow(Show show)
		{
			await this.Put("api/show", show);
		}

		public async Task DeleteShow(int id)
		{
			await this.Delete(String.Format("api/show/{0}", id.ToString()));
		}

		private HttpClient GetClient()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(ApiRouter.ApiUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}

		private Exception BuildException(HttpStatusCode code, string reasonPhrase)
		{
			switch (code)
			{
				case HttpStatusCode.NotFound:
					return new InvalidKeyException();

				default:
					return new HttpException((int)code, reasonPhrase);
			}
		}

		private async Task<T> Get<T>(string url)
		{
			using (var client = this.GetClient())
			{
				HttpResponseMessage response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsAsync<T>();
					return result;
				}
				else
				{
					throw this.BuildException(response.StatusCode, response.ReasonPhrase);
				}
			}
		}

		private async Task Post(string url, object data)
		{
			using (var client = this.GetClient())
			{
				HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
				if (!response.IsSuccessStatusCode)
				{
					throw this.BuildException(response.StatusCode, response.ReasonPhrase);
				}
			}
		}

		private async Task Put(string url, object data)
		{
			using (var client = this.GetClient())
			{
				HttpResponseMessage response = await client.PutAsJsonAsync(url, data);
				if (!response.IsSuccessStatusCode)
				{
					throw this.BuildException(response.StatusCode, response.ReasonPhrase);
				}
			}
		}

		private async Task Delete(string url)
		{
			using (var client = this.GetClient())
			{
				HttpResponseMessage response = await client.DeleteAsync(url);
				if (!response.IsSuccessStatusCode)
				{
					throw this.BuildException(response.StatusCode, response.ReasonPhrase);
				}
			}
		}
	}
}
