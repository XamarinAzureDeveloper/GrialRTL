using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Reflection;
using System.Globalization;
using GrialRTLService.Views;

namespace GrialRTLService
{
	//[XamlCompilation (XamlCompilationOptions.Skip)]
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;

		internal static CultureInfo		_currentCulture;

		internal static CultureInfo CurrentCulture
		{
			get {  return _currentCulture; }
			set
			{
				_currentCulture = value;

				/// call os specific implementation to set the current culture
				ILocalizer	OSLocalizer	= DependencyService.Get<ILocalizer>();

				if(OSLocalizer != null)
					OSLocalizer.SetLocale(_currentCulture); // set the Thread for locale-aware methods

				Application.Current.Resources.MergedWith = IsRTL ? typeof(RTLTheme) : typeof(LTRTheme);
				UiTextVm.Instance.RaisePropertyChanged();
			}
		}

		public static bool IsRTL
		{
			get {  return _currentCulture == null ? false : _currentCulture.Name.StartsWith("ar"); }
		}



		public App()
		{
			InitializeComponent();

			CurrentCulture	= new CultureInfo("en");
			MainPage = GetMainPage();
		}

		public static Page GetMainPage()
        {
			//return new WelcomeStarterPage();
			return new NavigationPage( new MainPage() );
        }
	}
}
