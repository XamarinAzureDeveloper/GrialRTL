using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xamarin.Forms;

using GrialRTLService.Views;

namespace GrialRTLService
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));

			btnRequestFormPage.Command = new Command((v) => OnRequestFormPageClicked(this, null));
			btnRequestThemePage.Command = new Command((v) => OnRequestThemePageClicked(this, null));
			btnRequestWelcomePage.Command = new Command((v) => OnRequestWelcomePageClicked(this, null));
			btnRequestNewsListPage.Command = new Command((v) => OnRequestNewsListPageClicked(this, null));
			btnRequestNewsDetailPage.Command = new Command((v) => OnRequestNewsDetailPageClicked(this, null));
			btnOfferCategoryListPage.Command = new Command((v) => OnRequestOfferCategoryListPageClicked(this, null));
		}

		public async void OnRequestFormPageClicked(object sender, EventArgs e){
			var page = new RequestFormPage();
			await Navigation.PushAsync(page);
		}

		public async void OnRequestThemePageClicked(object sender, EventArgs e){
			var page = new ThemePage();
			await Navigation.PushAsync(page);
		}

		public async void OnRequestWelcomePageClicked(object sender, EventArgs e)
		{
			var page = new WelcomePage();
			await Navigation.PushAsync(page);
		}

		public async void OnRequestNewsListPageClicked(object sender, EventArgs e)
		{
			var page = new NewsListPage();
			await Navigation.PushAsync(page);
		}

		public async void OnRequestNewsDetailPageClicked(object sender, EventArgs e)
		{
			var page = new NewsDetailPage();
			await Navigation.PushAsync(page);
		}


		public async void OnRequestOfferCategoryListPageClicked(object sender, EventArgs e)
		{
			var page = new OfferCategoryListPage();
			await Navigation.PushAsync(page);
		}


	}
}
