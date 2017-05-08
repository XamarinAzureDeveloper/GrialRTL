using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GrialRTLService;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ServiceTech
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
//			client.DefaultRequestHeaders.Add("x-zumo-application", "Test");
		}

		/*
		*	Get News List
        * http://pnews.mofa.gov.qa/api/PublicNews/?language={language}[&page_num={page_num}&page_limit={page_limit}&searchterms={searchterms}&from_date={from_date}&to_date={to_date}&featured={featured}	]
		*	Method : Get
		*/
		public async Task<List<Post>> GetNewsList()
		{
			var uri = new Uri(string.Format(Constant.BASE_URL + "PublicNews/?language=en&page_num=1"));

			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					var listCalls = JsonConvert.DeserializeObject<List<Post>>(result);
					Debug.WriteLine("Log:Response:" + result);
					return listCalls;
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

		// upload image sync task example
		public async Task<object> updateUserInfo(String profileImage)
		{
			Dictionary<string, string> pairs = new Dictionary<string, string>();
			byte[] fileToUpload = new byte[100];                                //image to Upload

			if (profileImage != null)
			{
				pairs.Add("imgName", "imgProfile");
				pairs.Add("imgExt", "jpg");
				//pairs.Add("imgBase64", user.profileImage);
				pairs.Add("imgUpdate", "YES");
			}
			else
			{
				pairs.Add("imgUpdate", "NO");
			}

			var uri = new Uri(string.Format(Constant.ImageUploadURL));
			try
			{
				string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
				//FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);
				MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
				//multipartContent.Headers.Add("Content-Type", "multipart/form-data");

				foreach (var pair in pairs)
				{
					multipartContent.Add(new StringContent(pair.Value != null ? pair.Value : ""), pair.Key);
				}

				if (profileImage != null)
				{
					var fileContent = new ByteArrayContent(fileToUpload);
					fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
					fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
					{
						Name = "fileToUpload",
						FileName = "imgProfile.jpg"
					};

					multipartContent.Add(fileContent);
				}

				var response = await client.PostAsync(uri, multipartContent);
				//var response = await client.PostAsync(uri, formContent);
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsStringAsync();
					var json = Newtonsoft.Json.Linq.JObject.Parse(result);
					var dicts = JsonConvert.SerializeObject(json["userInfo"]);
					var state = JsonConvert.SerializeObject(json["status"]);
					if (state.Contains("fail"))
					{
						return "" + json["message"];
					}

					if (state.Contains("success"))
					{
						var imgUrl = JsonConvert.SerializeObject(json["imgUrl"]);
						if (imgUrl != null)
						{
						}
					}
				}
				else
				{
					Debug.WriteLine(@"Failed.");
					return "Failed";
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
				return ex.Message;
			}
			return true;
		}
	}
}