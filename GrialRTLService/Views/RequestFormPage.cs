using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Rg.Plugins.Popup.Extensions;

namespace GrialRTLService.Views
{
	public partial class RequestFormPage : ContentPage
	{
		public RequestFormPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL, BindingContext as MaritalStatusChangeRequestVm));
		}

		private async void OnOpenAttachmentOptionsPopup(object sender, EventArgs e)
		{
			MaritalStatusChangeRequestVm vm = this.BindingContext as MaritalStatusChangeRequestVm;

			if (vm == null)
				return;

			var page = new AttachmentsOptionsPopupPage(vm);
			await Navigation.PushPopupAsync(page);
		}


	}
}
