using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrialRTLService
{
	public partial class NewsDetailPage : ContentPage
	{
		public NewsDetailPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;
			BindingContext = new ArticleViewModel();

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));
		}
	}
}
