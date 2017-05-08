using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using  GrialRTLService.Helpers;

namespace GrialRTLService
{
	/// <summary>
	/// list an enum type members (fields). track selected item. provide selected value
	/// </summary>
	/// <typeparam name="T">the enum type to scan</typeparam>
	public class EnumOptionList<T> :  ObservableRangeCollection<EnumOptionItem>
	{
		EnumOptionItem		_selectedItem;

		public EnumOptionList()
		{
			RebuildList();
		}

		/// <summary>
		/// current selected enum option
		/// </summary>
		public EnumOptionItem SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem	= value;
				
				NotifyPropertyChanged(() => SelectedItem);
				NotifyPropertyChanged(() => SelectedValue);
			}
		}

		/// <summary>
		/// current selected int value
		/// </summary>
		public int SelectedValue
		{
			get { return _selectedItem == null ? -1 : _selectedItem.OptionValue; }
		}

		/// <summary>
		/// scan the enum type and build the list
		/// </summary>
		private void RebuildList()
		{
			this.Clear();
			SelectedItem	= null;

			Type		type	= typeof(T);

			if(! type.GetTypeInfo().IsEnum)
				return;

			var		values	= Enum.GetValues(type);

			foreach(var value in values)
			{
				this.Add(new EnumOptionItem(value as Enum));
			}
		}
	}


	/// <summary>
	/// an enum option. with description and value
	/// </summary>
	public class EnumOptionItem :  ObservableObject
	{
		Enum		_option;

		public EnumOptionItem()
		{

		}

		public EnumOptionItem(Enum option)
		{
			Option		= option;
		}

		/// <summary>
		/// the description of the enum option (using the Description attribute)
		/// </summary>
		public string Description
		{
			get { return _option.EnumDescriptionLocalized(); }
		}

		/// <summary>
		/// the enum option
		/// </summary>
		public Enum Option
		{
			get { return _option; }
			set
			{
				if(value == _option)
					return;

				_option = value;
				NotifyPropertyChanged(() => Option);
				NotifyPropertyChanged(() => Description);
				NotifyPropertyChanged(() => OptionValue);
			}
		}

		/// <summary>
		/// the option int value
		/// </summary>
		public int OptionValue
		{
			get { return _option == null ? -1 : _option.EnumValue(); }
		}
	}

}
