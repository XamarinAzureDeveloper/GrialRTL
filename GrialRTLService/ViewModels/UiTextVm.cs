using GrialRTLService.Helpers;
using GrialRTLService.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrialRTLService
{
	public class UiTextVm : ObservableObject
	{
		static UiTextVm			_instance;

		public static UiTextVm Instance
		{
			get
			{
				if(_instance == null)
					_instance = new UiTextVm();

				return _instance;
			}
		}


		public UiTextVm()
		{
			if(_instance == null)
				_instance	= this;
		}

		public void RaisePropertyChanged()
		{
			NotifyPropertyChanged(null);
		}

		public string GrialName
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.Grial); }
		}

		public string WelcomeToGrialRTLServiceApp
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.WelcomeToGrialRTLServiceApp); }
		}

		public string PageTheme
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.PageTheme); }
		}

		public string PageRequestForm
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.PageRequestForm); }
		}

	}
}
