using System;
using System.Globalization;

namespace GrialRTLService
{
	public interface ILocalizer
	{
		//CultureInfo GetCurrentCultureInfo();
		void SetLocale(CultureInfo ci);
	}
}
