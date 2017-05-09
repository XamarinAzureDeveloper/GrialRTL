using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		private ObservableCollection<News> _listOfItems;
		private ObservableCollection<News> _listOfItems_en;
		bool isLoading = false;
		int page_num = 1;
		bool isNext = true;
		string language = "ar";

		public NewsListPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			//BindingContext = new PostsViewModel();
			_listOfItems = new ObservableCollection<News>();
			_listOfItems_en = new ObservableCollection<News>();

			getNews();

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));

			btnToggleRTL.Clicked += (sender, e) =>
			{
				if (language == "en")
				{
					newsListview.ItemsSource = _listOfItems;
					language = "ar";
				}
				else
				{
					newsListview.ItemsSource = _listOfItems_en;
					language = "en";
				}
			};

			newsListview.ItemAppearing += (sender, e) => 
			{
				if(isLoading || _listOfItems.Count == 0)
					return;

				if(e.Item == _listOfItems[_listOfItems.Count - 1] || e.Item == _listOfItems_en[_listOfItems.Count - 1])
				{
					page_num++;
					getNews();
				}
			};
		}

		async void getNews()
		{
			if (!isNext) return;

			isLoading = true;
			centerIndicator.IsVisible = true;
			var result = await new APIManager().GetNewsList("ar", page_num);
			var result_en = await new APIManager().GetNewsList("en", page_num);
			centerIndicator.IsVisible = false;
			isLoading = false;

			var json = Newtonsoft.Json.Linq.JObject.Parse(result.ToString());
			var newsList = JsonConvert.SerializeObject(json["PublicNewsList"]);
			var count = JsonConvert.SerializeObject(json["Total"]);

			List<News> newsArray = JsonConvert.DeserializeObject<List<News>>(newsList.ToString());
			foreach (News news in newsArray) {
				_listOfItems.Add(news);
				if (news.id == int.Parse(count)) isNext = false;
			}

			var json_en = Newtonsoft.Json.Linq.JObject.Parse(result_en.ToString());
			var newsList_en = JsonConvert.SerializeObject(json_en["PublicNewsList"]);
			List<News> newsArray_en = JsonConvert.DeserializeObject<List<News>>(newsList_en.ToString());
			foreach (News news in newsArray_en) {
				_listOfItems_en.Add(news);
			}

			if (language == "en")
			{
				newsListview.ItemsSource = _listOfItems_en;
			}
			else
			{
				newsListview.ItemsSource = _listOfItems;
			}

			Debug.WriteLine("Log:Response:" + result);

		}

	}
}
