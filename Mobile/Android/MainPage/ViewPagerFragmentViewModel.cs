using System;
using GalaSoft.MvvmLight;

namespace Android
{
	public class ViewPagerFragmentViewModel : ViewModelBase
	{
		public event EventHandler<SwipeToTabEventHandler> SwipeToTabEvent;

		public override void OnCreate ()
		{
			SubscribeServices();
		}

		void SubscribeServices ()
		{
			MessengerInstance.Register<NotifySearchBarPutText>(this, OnSearchBarPutText);
		}

		void OnSearchBarPutText (NotifySearchBarPutText parameter)
		{
			var tab = new SwipeToTabEventHandler
			{
				Tab = Tab.JobSearch
			};

			OnSwipeToTabEvent(tab);
		}

		protected virtual void OnSwipeToTabEvent (SwipeToTabEventHandler e)
		{
			var handler = SwipeToTabEvent;
			if (handler != null)
				handler (this, e);
		}
	}
}

