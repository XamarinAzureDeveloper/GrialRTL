using GrialRTLService.Localization.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GrialRTLService.Localization
{
	public static partial class ResourceKeys
	{
		public static string ResourceString(string keyName)
		{
			if (string.IsNullOrEmpty(keyName) || ! Enum.IsDefined(typeof(ResourceKey), keyName))
				return "";

			ResourceKey		key	= (ResourceKey) Enum.Parse(typeof(ResourceKey), keyName);
			return ResourceString(key);
		}


		public static string ResourceString(ResourceKey keyValue)
		{
			string		keyName	= Enum.GetName(typeof(ResourceKey), keyValue);

			ResourceManager rm		= AppResources.ResourceManager;
			string			value	= rm.GetString(keyName, App.CurrentCulture);

			return string.IsNullOrEmpty(value) ? keyName : value;
		}
	}

}
