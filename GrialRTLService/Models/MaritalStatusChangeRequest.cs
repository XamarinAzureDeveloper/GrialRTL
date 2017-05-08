using GrialRTLService.Helpers;
using GrialRTLService.Localization.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrialRTLService.Localization;

namespace GrialRTLService
{
	[Description(ResourceKey.SelectMaritalStatusLabel)]         /// label of the choice value
	public enum MaritalStatusOption
	{
		[Description(ResourceKey.Option_Married)]      /// label of married option
		_married	= 3,

		[Description(ResourceKey.Option_Divorced)]     /// label of divorced option
		_divorced = 4,

		[Description(ResourceKey.Option_Single)]       /// label of single option
		_single = 2,

		[Description(ResourceKey.Option_Widow)]        /// label of widow option
		_widow = 1,
	};



	[Description(ResourceKey.RequestFormPageTitle)]        /// age title of marital status request form
	public class MaritalStatusChangeRequest : ObservableObject
	{
		public static EnumOptionList<MaritalStatusOption> OptionList	 = new EnumOptionList<MaritalStatusOption>();

		MaritalStatusOption		_newStatus		= MaritalStatusOption._single;
		MaritalStatusOption		_oldStatus		= MaritalStatusOption._single;

		DateTime				_requestDate	= DateTime.Today;
		TimeSpan				_requestTime	= new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
		int						_requestNumber	= 2;
		// sample comments
		string					_comments		= "تعليقات خط 1\n"	+
												 "تعليقات خط 2",
								_requestReason	= Enum.GetName(typeof(ResourceKey), ResourceKey.RequestReasonNew);


		public MaritalStatusChangeRequest()
		{

		}

		public MaritalStatusChangeRequest(MaritalStatusOption currentStatus)
		{
			_newStatus = currentStatus;
		}

		[Description(ResourceKey.CurrentMaritalStatusLabel)]     /// label of new marital status property
		public MaritalStatusOption NewStatus
		{
			get { return _newStatus; }
			set
			{
				if(value == _newStatus)
					return;

				_newStatus = value;
				OnPropertyChanged();
			}
		}

		[Description(ResourceKey.LastMaritalStatusLabel)]     /// label of old marital status property
		public MaritalStatusOption OldStatus
		{
			get { return _oldStatus; }
			set
			{
				if(value == _oldStatus)
					return;

				_oldStatus = value;
				OnPropertyChanged();
			}
		}

		[Description(ResourceKey.SelectDateLabel)]     /// label of request date
		public DateTime RequestDate
		{
			get {  return _requestDate; }
			set
			{
				_requestDate	= value;
				OnPropertyChanged();
			}
		}

		[Description(ResourceKey.SelectTimeLabel)]     /// label of request time
		public TimeSpan RequestTime
		{
			get {  return _requestTime; }
			set
			{
				_requestTime	= value;
				OnPropertyChanged();
			}
		}

		[Description(ResourceKey.RequestNumberLabel)]     /// label of requeust number
		public int RequestNumber
		{
			get {  return _requestNumber; }
			set
			{
				_requestNumber	= value;
				OnPropertyChanged();
			}
		}


		[Description(ResourceKey.CommentsLabel)]     /// label of request comments
		public string RequestComments
		{
			get {  return _comments; }
			set
			{
				_comments = value;
				OnPropertyChanged();
			}
		}

		[Description(ResourceKey.RequestReasonLabel)]     /// label of request reason
		public string RequestReason
		{
			get {  return _requestReason; }
			set
			{
				_requestReason	= value;
				OnPropertyChanged();
			}
		}

	}

}
