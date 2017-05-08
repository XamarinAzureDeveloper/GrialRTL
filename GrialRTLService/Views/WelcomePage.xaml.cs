using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrialRTLService
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));
		}
	}
}
