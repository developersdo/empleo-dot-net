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

