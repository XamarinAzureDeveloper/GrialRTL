using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GrialRTLService
{
	public partial class NewsListPage : ContentPage
	{
		public NewsListPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			//BindingContext = new PostsViewModel();

			getNews();

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));
		}

		async void getNews()
		{
			var result = await new APIManager().GetNewsList();
			var json = Newtonsoft.Json.Linq.JObject.Parse(result.ToString());
			var count = JsonConvert.SerializeObject(json["Total"]);
			var newsList = JsonConvert.SerializeObject(json["PublicNewsList"]);

			var listCalls = JsonConvert.DeserializeObject<List<Post>>(newsList.ToString());
			Debug.WriteLine("Log:Response:" + result);
			BindingContext = listCalls;

		}
	}
}
