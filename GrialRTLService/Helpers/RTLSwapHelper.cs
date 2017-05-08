using GrialRTLService.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrialRTLService
{
	public static class RTLSwapHelper
	{
		public static void UpdateItem(ToolbarItem sender)
		{
			if(sender == null)
				return;

			sender.Text = App.IsRTL ? "LTR>" : "RTL<";
		}

		public static void HandleMirrorClicked(ToolbarItem sender, ObservableObject observable = null)
		{
			CultureInfo ci;
			if (!App.IsRTL)
			{
				ci = new CultureInfo("ar");
			}
			else
			{
				ci = new CultureInfo("en");
			}

			App.CurrentCulture = ci;		// theme is set here
			observable?.NotifyAllPropertiesChanged();

			UpdateItem(sender);
		}
	}
}
