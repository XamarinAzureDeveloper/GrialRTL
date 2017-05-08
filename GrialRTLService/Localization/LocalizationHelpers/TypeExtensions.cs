using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GrialRTLService
{
	/// <summary>
	/// extensions for types and enumertion: get the description of a type, property or enum value
    /// used to find the Description attribute of a class or a property 
    ///     (Descriptions are used for page titles and property labels to ease language-specific terms)
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// get the description string of a type (class)
		/// </summary>
		/// <param name="objectType">the Type</param>
		/// <returns>the description attribute value for the class</returns>
		public static string DescriptionLocalized(this Type objectType)
		{
			if(objectType == null)
				return null;

			TypeInfo	typeInfo	= objectType.GetTypeInfo();
			var			attrib		= typeInfo.GetCustomAttribute<DescriptionAttribute>();

			return attrib == null ? null : attrib.LocalizedString;
		}

		/// <summary>
		/// get the description attribute (label) of an object (= description of its class)
		/// </summary>
		/// <param name="obj">the object</param>
		/// <returns>the description (label) of the object's class</returns>
		public static string Description(this object obj)
		{
			if(obj == null)
				return null;

			return obj.GetType().DescriptionLocalized();
		}

		/// <summary>
		/// get the description of a property info
		/// </summary>
		/// <param name="property">the property info</param>
		/// <returns>the description (label) of the property</returns>
		public static string DescriptionLocalized(this PropertyInfo property)
		{
			if(property == null)
				return null;

			var		attrib	= property.GetCustomAttribute<DescriptionAttribute>();
			return attrib == null ? null : attrib.LocalizedString;
		}

		/// <summary>
		/// get the member description (label = description attribute)
		/// </summary>
		/// <param name="member">the member (property / method / field...)</param>
		/// <returns>the description if defined</returns>
		public static string MemberDescription(this MemberInfo member)
		{
			if(member == null)
				return null;

			//var		expression = Expression.Field( Expression.Constant(member.DeclaringType), member.Name);
			var		attrib		= member.GetCustomAttribute<DescriptionAttribute>();

			return attrib == null ? null : attrib.DescriptionName;
		}

		public static string MemberDescriptionLocalized(this MemberInfo member)
		{
			if(member == null)
				return null;

			//var		expression = Expression.Field( Expression.Constant(member.DeclaringType), member.Name);
			var		attrib		= member.GetCustomAttribute<DescriptionAttribute>();

			return attrib == null ? null : attrib.LocalizedString;
		}


		/// <summary>
		/// get the description (label) of an enum field
		/// </summary>
		/// <param name="value">the enum value</param>
		/// <returns>the string description (label) of the enum value (= Description attribute)</returns>
		public static string EnumDescriptionLocalized(this Enum value)
		{
			if(value == null)
				return null;

			var			type		= value.GetType();
			TypeInfo	typeInfo	= type.GetTypeInfo();
			string		typeName	= Enum.GetName(type, value);

			if (string.IsNullOrEmpty(typeName))
				return null;

			var			field		= typeInfo.DeclaredFields.FirstOrDefault(f => f.Name == typeName);

			if(field == null)
				return typeName;

			var		attrib		= field.GetCustomAttribute<DescriptionAttribute>();

			return attrib == null ? typeName : attrib.LocalizedString;
		}

		/// <summary>
		/// get the enum int value
		/// </summary>
		/// <param name="value">the enum option</param>
		/// <returns>the int value of the neum option</returns>
		public static int EnumValue(this Enum value)
		{
			if(value == null)
				return 0;

			var			fieldType	= value.GetType();
			string		fieldName	= Enum.GetName(fieldType, value);

			if (string.IsNullOrEmpty(fieldName))
				return 0;

			var		values		= Enum.GetValues(fieldType);

			foreach(var v in values)
			{
				if(Enum.GetName(fieldType, v) == fieldName)
					return (int) v;
			}

			return 0;
		}

		/// <summary>
		/// get the description attribute (label) of a member expression
		/// usage sample: string propertyLabel = PropertyDescription(()=> PropertyName);
		/// </summary>
		/// <typeparam name="TMember">the expression (in the above sample: '()=> PropertyName') </typeparam>
		/// <param name="memberExpression">the member name</param>
		/// <returns>the description. null if not found</returns>
		public static string PropertyDescriptionLocalized<TMember>(Expression<Func<TMember>> memberExpression)
		{
			if (memberExpression == null)
				return null;

			var		expression = memberExpression.Body as MemberExpression;
			var		member		= expression == null ? null : expression.Member;

			if (member == null)
				return null;

			return member.MemberDescriptionLocalized();
		}

	}

}
