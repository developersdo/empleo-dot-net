using System;
using PropertyChanged;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace Android
{
	[ImplementPropertyChanged]
	public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler (this, e);
		}

		public ViewModelBase ()
		{
		}

		public virtual void OnCreate()
		{
			
		}

		public virtual void OnStop ()
		{

		}

		public virtual void OnResume ()
		{

		}
	}
}

