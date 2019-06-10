using System;
using Xamarin.Forms;
using FreshMvvm;
using OfficeHoursControlTemplateExample.PageModels;
using System.ComponentModel;

namespace OfficeHoursControlTemplateExample.Pages
{
	public class AppPage : ContentPage
	{
		protected AppPageModel _pageModel;

		public AppPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (this.BindingContext != null)
			{
				_pageModel = (AppPageModel)this.BindingContext;
				_pageModel.PropertyChanged += HandlePropertyChanged;

				UpdateLayout();
			}
		}

		private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(MainPageModel.UpdateViewForOrientationChange))
			{
				UpdateLayout();
			}
		}

		private void UpdateLayout()
		{
			if (Device.Idiom == TargetIdiom.Phone)
			{
				if (_pageModel.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
				{
					_pageModel.PageControlTemplate = this.Resources["phonePortrait"] as ControlTemplate;
				}
				else
				{
					_pageModel.PageControlTemplate = this.Resources["phoneLandscape"] as ControlTemplate;
				}
			}
			else
			{
				if (_pageModel.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait)
				{
					_pageModel.PageControlTemplate = this.Resources["tabletPortrait"] as ControlTemplate;
				}
				else
				{
					_pageModel.PageControlTemplate = this.Resources["tabletLandscape"] as ControlTemplate;
				}
			}
		}
	}
}
