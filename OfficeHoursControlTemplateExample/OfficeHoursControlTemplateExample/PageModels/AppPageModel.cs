using System;
using FreshMvvm;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OfficeHoursControlTemplateExample.PageModels
{
	public class AppPageModel : FreshBasePageModel
	{
		private DisplayOrientation _orientation;
		private ControlTemplate _controlTemplate;
		private bool _updateViewForOrientationChange;

		public AppPageModel()
		{
			Orientation = App.Orientation;
		}

		protected override void ViewIsAppearing(object sender, EventArgs e)
		{
			base.ViewIsAppearing(sender, e);

			//subscribe to orientation changes
			App.AppOrientationChanged -= HandleOrientationChanged;
			App.AppOrientationChanged += HandleOrientationChanged;
		}

		protected override void ViewIsDisappearing(object sender, EventArgs e)
		{
			base.ViewIsDisappearing(sender, e);

			//unsubscribe to orientation changes
			App.AppOrientationChanged -= HandleOrientationChanged;
		}

		private void HandleOrientationChanged(Xamarin.Essentials.DisplayOrientation orientation)
		{
			System.Diagnostics.Debug.WriteLine($"AppPageModel.HandleOrientationChanged: { orientation.ToString() }");

			Orientation = orientation;
			UpdateViewForOrientationChange = true;
		}

		public bool UpdateViewForOrientationChange
		{
			get
			{
				return _updateViewForOrientationChange;
			}
			set
			{
				_updateViewForOrientationChange = value;
				RaisePropertyChanged();
			}
		}

		public DisplayOrientation Orientation
		{
			get
			{
				return _orientation;
			}
			set
			{
				_orientation = value;
			}
		}

		public ControlTemplate PageControlTemplate
		{
			get
			{
				return _controlTemplate;
			}
			set
			{
				_controlTemplate = value;
				RaisePropertyChanged();
			}
		}
	}
}
