using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GrialRTLService
{
	public partial class OfferCategoryListPage : ContentPage
	{
		public OfferCategoryListPage()
		{
			InitializeComponent();
			Resources = Application.Current.Resources;

			BindingContext = SamplesDefinition.SamplesCategories.Values;

			RTLSwapHelper.UpdateItem(btnToggleRTL);
			btnToggleRTL.Command = new Command(v => RTLSwapHelper.HandleMirrorClicked(btnToggleRTL));
		}
	}
}
