using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Android
{
	public class ViewPagerFragmentViewModel : ViewModelBase
	{
		public event EventHandler<SwipeToTabEventHandler> SwipeToTabEvent;

		public int CurrentPage { get; set; }

		public RelayCommand<int> PageScrolledCommand { get; set; }

		public override void OnCreate ()
		{
			PageScrolledCommand = new RelayCommand<int>(OnPageScrolled);

			SubscribeServices();
		}

		void OnPageScrolled (int position)
		{
			CurrentPage = position;
		}

		void SubscribeServices ()
		{
			MessengerInstance.Register<NotifySearchBarPutText>(this, OnSearchBarPutText);
			MessengerInstance.Register<NotifyUserChangedQuery>(this, OnNotifyUserChangedQuery);
		}

		void OnNotifyUserChangedQuery (NotifyUserChangedQuery parameter)
		{
			var page = (Tab) CurrentPage;

			switch(page)
			{
			case Tab.JobSearch:
				{
					SendMessageTo<NotifyJobListUserChangedQuery>(new NotifyJobListUserChangedQuery
						{
							Query = parameter.Query
						});
				}
				break;
			case Tab.Favorite:
				{
					SendMessageTo<NotifyFavoriteListUserChangedQuery>(new NotifyFavoriteListUserChangedQuery
						{
							Query = parameter.Query
						});
				}
				break;
			}
		}

		void SendMessageTo<T>(T arg)
		{
			MessengerInstance.Send<T>(arg);
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

