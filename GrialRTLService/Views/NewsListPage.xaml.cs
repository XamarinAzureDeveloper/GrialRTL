using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrialRTLService
{
	public partial class NewsListPage : ContentPage
	{
		public NewsListPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			BindingContext = new PostsViewModel();

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));
		}
	}
}
