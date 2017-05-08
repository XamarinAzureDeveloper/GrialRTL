using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrialRTLService.Helpers;
using GrialRTLService.Localization;
using System.Globalization;

namespace GrialRTLService
{
	public class MaritalStatusChangeRequestVm : ObservableObject	//, IExplicitNotifyPropertyChanged
	{
		MaritalStatusChangeRequest		_dataObject		= new MaritalStatusChangeRequest();

		public MaritalStatusChangeRequestVm(): base()
		{

		}

		public MaritalStatusChangeRequestVm(MaritalStatusChangeRequest dataObject)
		{
			_dataObject	= dataObject;
		}

		public MaritalStatusChangeRequest DataObject
		{
			get { return _dataObject; }
			set
			{
				_dataObject = value;
				NotifyPropertyChanged(null);	// all properties changed
			}
		}

		public DateTime RequestDayDate
		{
			get {  return _dataObject == null ? DateTime.Today : _dataObject.RequestDate; }
			set
			{
				if(_dataObject == null)
					return;
				_dataObject.RequestDate = value;
				NotifyPropertyChanged(() => RequestDayDate);
				NotifyPropertyChanged(() => RequestDateTime);
			}
		}

		public TimeSpan RequestTime
		{
			get {  return _dataObject == null ? new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) : _dataObject.RequestTime; }
			set
			{
				if(_dataObject == null)
					return;
				_dataObject.RequestTime = value;
				NotifyPropertyChanged(() => RequestTime);
				NotifyPropertyChanged(() => RequestDateTime);
			}
		}


		public DateTime RequestDateTime
		{
			get { return new DateTime(RequestDayDate.Year, RequestDayDate.Month, RequestDayDate.Day, RequestTime.Hours, RequestTime.Minutes, RequestTime.Seconds); }
		}


		public string PageTitle
		{
			get {  return typeof(MaritalStatusChangeRequest).DescriptionLocalized(); }
		}

		public string OldMaritalStatusLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.LastMaritalStatusLabel) : TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.OldStatus); }
		}

		public string NewMaritalStatusLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.CurrentMaritalStatusLabel) : TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.NewStatus); }
		}

		public string SelectDateLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.SelectDateLabel) : TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.RequestDate); }
		}

		public string SelectTimeLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.SelectTimeLabel) : TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.RequestTime); }
		}

		public string RequestReasonLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.RequestReasonLabel) : TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.RequestReason); }
		}

		public string RequestNumberLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.RequestNumberLabel): TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.RequestNumber); }
		}

		public string CommentsLabel
		{
			get {  return _dataObject == null ? ResourceKeys.ResourceString(ResourceKey.CommentsLabel) : TypeExtensions.PropertyDescriptionLocalized(() => _dataObject.RequestComments); }
		}

		public string SubmitButton
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.SubmitButton); }
		}


		public string CancelButton
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.CancelButton); }
		}

		public string AttachmentLabel
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.AttachmentLabel); }
		}

		//  Please enter a valid e-mail
		public string InvalidEmailMessage
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.MsgInvalidEmail); }
		}

		// Type invalid email to see error
		public string WriteInvalidEmailText
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.MsgWriteInvalidEmail); }
		}

		public string ReadonlyEntryText
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.MsgReadonlyEntry); }
		}

		public string DatePickerLabel
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.SelectDateLabel); }
		}

		public string PickerSelectLabel
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.SelectDateLabel); }
		}

		public string AttachOptionPickFromGallery
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.Option_PickFromGallery); }
		}

		public string AttachOptionAttachFile
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.Option_AttachFile); }
		}

		public string AttachOptionUseCamera
		{
			get {  return ResourceKeys.ResourceString(ResourceKey.Option_UseCamera); }
		}


		public List<string> AttachementOptions
		{
			get
			{
				return new List<string>()
				{
					AttachOptionAttachFile,
					AttachOptionUseCamera,
					AttachOptionPickFromGallery,
				};
			}
		}

		public EnumOptionList<MaritalStatusOption> MaritalStatusOptions
		{
			get {  return MaritalStatusChangeRequest.OptionList; }
		}

		public List<string> MaritalStatusOptionsNames
		{
			get
			{
				List<string>	list	= new List<string>();

				var	options	= MaritalStatusChangeRequest.OptionList;
				foreach(var item in options)
				{
					list.Add(item.Description);
				}

				return list;
			}
		}

		//public void NotifyPropertyChanged()
		//{
		//	NotifyPropertyChanged(null);
		//}
	}
}
