using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreshMvvm;
using OfficeHoursControlTemplateExample.PageModels;
using Xamarin.Essentials;

namespace OfficeHoursControlTemplateExample
{
	public partial class App : Application
	{
		public delegate void AppOrientationChangedHandler(DisplayOrientation orientation);
		public static event AppOrientationChangedHandler AppOrientationChanged;

		private static DisplayOrientation _orientation;

		public App()
		{
			InitializeComponent();

			//set current orientation
			_orientation = DeviceDisplay.MainDisplayInfo.Orientation;
			MonitorOrientationChanges();

			var page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();
			var basicNavContainer = new FreshNavigationContainer(page);
			MainPage = basicNavContainer;
		}

		private void MonitorOrientationChanges()
		{
			DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
		}

		private void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
		{
			var displayInfo = e.DisplayInfo;

			// Process changes
			//Debug.WriteLine($"App.xaml.cs.OnMainDisplayInfoChanged() { displayInfo.Orientation }");
			if (_orientation != displayInfo.Orientation)
			{
				//orientation was changed - send event update
				_orientation = DeviceDisplay.MainDisplayInfo.Orientation;

				if (AppOrientationChanged != null)
				{
					AppOrientationChanged(_orientation);
				}
			}
		}

		public static DisplayOrientation Orientation
		{
			get
			{
				return _orientation;
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
