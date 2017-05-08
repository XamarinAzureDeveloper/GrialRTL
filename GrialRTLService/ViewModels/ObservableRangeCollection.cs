using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace GrialRTLService.Helpers
{
	/// <summary> 
	/// Represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed. 
	/// </summary> 
	/// <typeparam name="T"></typeparam> 
	public class ObservableRangeCollection<T> : ObservableCollection<T>
	{
		public new event PropertyChangedEventHandler PropertyChanged;

		/// <summary> 
		/// Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class. 
		/// </summary> 
		public ObservableRangeCollection()
			: base()
		{
		}

		/// <summary> 
		/// Initializes a new instance of the System.Collections.ObjectModel.ObservableCollection(Of T) class that contains elements copied from the specified collection. 
		/// </summary> 
		/// <param name="collection">collection: The collection from which the elements are copied.</param> 
		/// <exception cref="System.ArgumentNullException">The collection parameter cannot be null.</exception> 
		public ObservableRangeCollection(IEnumerable<T> collection)
			: base(collection)
		{
		}

		/// <summary> 
		/// Adds the elements of the specified collection to the end of the ObservableCollection(Of T). 
		/// </summary> 
		public void AddRange(IEnumerable<T> collection, NotifyCollectionChangedAction notificationMode = NotifyCollectionChangedAction.Add)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			CheckReentrancy();

			if (notificationMode == NotifyCollectionChangedAction.Reset)
			{
				foreach (var i in collection)
				{
					Items.Add(i);
				}

				OnPropertyChanged(new PropertyChangedEventArgs("Count"));
				OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

				return;
			}

			int startIndex = Count;
			var changedItems = collection is List<T> ? (List<T>)collection : new List<T>(collection);
			foreach (var i in changedItems)
			{
				Items.Add(i);
			}

			OnPropertyChanged(new PropertyChangedEventArgs("Count"));
			OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startIndex));
		}

		/// <summary> 
		/// Removes the first occurence of each item in the specified collection from ObservableCollection(Of T). 
		/// </summary> 
		public void RemoveRange(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			foreach (var i in collection)
				Items.Remove(i);
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		/// <summary> 
		/// Clears the current collection and replaces it with the specified item. 
		/// </summary> 
		public void Replace(T item)
		{
			ReplaceRange(new T[] { item });
		}

		/// <summary> 
		/// Clears the current collection and replaces it with the specified collection. 
		/// </summary> 
		public void ReplaceRange(IEnumerable<T> collection)
		{
			if (collection == null)
				throw new ArgumentNullException("collection");

			Items.Clear();
			AddRange(collection, NotifyCollectionChangedAction.Reset);
		}

		protected void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
		{
			if (property == null)
				return;

			string		name		= GetPropertyName(property);

			if(string.IsNullOrEmpty(name))
				return;

			NotifyPropertyChanged( name);
		}

		protected void NotifyPropertyChanged([CallerMemberName]string property_name = "")
		{
			if (PropertyChanged != null)
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