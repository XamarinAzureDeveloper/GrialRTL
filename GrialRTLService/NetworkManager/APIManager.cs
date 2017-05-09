using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GrialRTLService;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GrialRTLService
{
	public class APIManager
	{
		private HttpClient client;

		public APIManager()
		{
			client = new HttpClient();                     
			client.Timeout = TimeSpan.FromMinutes(5);
			client.MaxResponseContentBufferSize = 256000;

			client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/x-www-form-urlencoded; charset=utf-8");
		}

		/*
		*	Get News List
        * http://pnews.mofa.gov.qa/api/PublicNews/?language={language}[&page_num={page_num}&page_limit={page_limit}&searchterms={searchterms}&from_date={from_date}&to_date={to_date}&featured={featured}	]
		*	Method : Get
		*/
		//public async Task<List<Post>> GetNewsList()
		//{
		//	var uri = new Uri(string.Format(Constant.BASE_URL + "PublicNews/?language=en&page_num=1"));

		//	try
		//	{
		//		var response = await client.GetAsync(uri);
		//		if (response.IsSuccessStatusCode)
		//		{
		//			var result = await response.Content.ReadAsStringAsync();
		//			var listCalls = JsonConvert.DeserializeObject<List<Post>>(result);
		//			Debug.WriteLine("Log:Response:" + result);
		//			return listCalls;
		//		}
		//	}
		//	catch (TaskCanceledException ex)
		//	{
		//		Debug.WriteLine(@"ERROR {0}", ex.Message);
		//		return null;
		//	}
		//	catch (Exception ex)
		//	{
		//		Debug.WriteLine(@"ERROR {0}", ex.Message);
		//		return null;
		//	}
		//	return null;
		//}

		public async Task<Object> GetNewsList(string lang, int page_num)
		{
			var uri = new Uri(string.Format(Constant.BASE_URL + "PublicNews/?language=" + lang + "&page_num=" + page_num) + "&page_limit=10");

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					return result;
				}
			}
			catch (TaskCanceledException ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
				return null;
			}
			return null;
		}

	}
}