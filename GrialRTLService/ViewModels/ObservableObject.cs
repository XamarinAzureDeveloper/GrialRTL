using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace GrialRTLService.Helpers
{
	/// <summary>
	/// Observable object with INotifyPropertyChanged implemented
	/// </summary>
	public class ObservableObject : INotifyPropertyChanged
	{
		/// <summary>
		/// Sets the property.
		/// </summary>
		/// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
		/// <param name="backingStore">Backing store.</param>
		/// <param name="value">Value.</param>
		/// <param name="propertyName">Property name.</param>
		/// <param name="onChanged">On changed.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		protected bool SetProperty<T>( ref T backingStore, T value,
										[CallerMemberName]string propertyName = "",
										Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		/// <summary>
		/// Occurs when property changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		internal void NotifyAllPropertiesChanged()
		{
			NotifyPropertyChanged(null);
		}

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		protected void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
		{
			if (property == null || PropertyChanged == null)
				return;

			string		name		= GetPropertyName(property);

			if(string.IsNullOrEmpty(name))
				return;

			NotifyPropertyChanged( name);
		}

		protected void NotifyPropertyChanged([CallerMemberName]string property_name = "")
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged.Invoke( this, new PropertyChangedEventArgs( property_name));
		}

		public static string GetPropertyName<TProperty>(Expression<Func<TProperty>> property)
		{
			if (property == null)
				return null;

			var expression = property.Body as MemberExpression;

			if (expression == null || expression.Member == null)
				return null;

			return expression.Member.Name;

		}
	}
}