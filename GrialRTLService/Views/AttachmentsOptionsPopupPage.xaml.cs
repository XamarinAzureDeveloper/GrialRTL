using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace GrialRTLService
{
	public partial class AttachmentsOptionsPopupPage : PopupPage
	{
		public AttachmentsOptionsPopupPage()
		{
			InitializeComponent();
		}

		public AttachmentsOptionsPopupPage(MaritalStatusChangeRequestVm vm)
		{
			InitializeComponent();
			this.BindingContext = vm;
		}

	}

}
