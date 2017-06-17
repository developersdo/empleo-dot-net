using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Transitions;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Helpers;
using Android.ViewModels;
using Android.Support.V7.Widget;
using Core;

namespace Android
{
	public class ViewStateToBool : IValueConverter
	{
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var state = (bool) value;

			return state ? ViewStates.Visible : ViewStates.Invisible;
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

	}
}

