
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.Resources;
using GrialRTLService.Localization.Resx;
using GrialRTLService.Localization;

namespace GrialRTLService
{
    /// <summary>
    /// this attribute can be used to set the 'human' description of an object, a property or an enum value
    /// ------------------------------------------------------
    /// How to use:
    /// ------------------------------------------------------
    /// * define your string constants (see LangStrings.cs)
    /// * set this attribute on a class using one of the string constants:
    ///     ex: [Description(LangStrings.MyClassName)]
    ///        (MyClassName can then be used, for instance, in the class's page title when relevant)
    /// * set this atribute on each of the class properties (using one of your string constants)
    ///     ex: [Description(LangStrings.MyPropertyName)]
    ///         (MyPropertyName can then be used as the property label in a control or on a page)
    /// </summary>
    [AttributeUsage(validOn: AttributeTargets.All, AllowMultiple = false,Inherited = false)]
	public class DescriptionAttribute : Attribute
	{
		//string			_description;
		ResourceKey		_resourceKey;

		//public DescriptionAttribute(string description)
		//{
		//	_description = description;
		//}

		public DescriptionAttribute(ResourceKey key)
		{
			_resourceKey = key;
		}

		//public string Description
		//{
		//	get {  return _description; }
		//	set {  _description = value; }
		//}

		public ResourceKey Description
		{
			get {  return _resourceKey; }
			set {  _resourceKey = value; }
		}

		public string DescriptionName
		{
			get {  return Enum.GetName(typeof(ResourceKey), _resourceKey); }
		}


		public string LocalizedString
		{
			get { return ResourceKeys.ResourceString(_resourceKey); }
		}
	}

}
