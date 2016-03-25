using System;
using PropertyChanged;

namespace Android
{
	[ImplementPropertyChanged]
	public class ViewModelBase
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

