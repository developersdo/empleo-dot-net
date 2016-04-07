using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Android
{
	public class AboutViewModel : ViewModelBase
	{
		public ObservableCollection<GithubUser> Contributors { get; set; }

		IGithubContributorService _contributorService;

		public event EventHandler<ContributorAddedEventHandler> ContributorAddedEvent;

		public AboutViewModel (IGithubContributorService contributorService)
		{
			_contributorService = contributorService;

			Contributors = new ObservableCollection<GithubUser>();
		}

		public override async void OnResume ()
		{
			await GetUsers();
		}

		async Task GetUsers ()
		{
			if(Contributors == null || !Contributors.Any())
			{
		 		var users = await _contributorService.GetAllContributors("empleado", "developersdo", "empleo-dot-net");

				foreach(var item in users)
				{
					Contributors.Add(item);

					OnContributorAddedEvent(new ContributorAddedEventHandler
						{
							User = item
						});
				}
			}
		}

		protected virtual void OnContributorAddedEvent (ContributorAddedEventHandler e)
		{
			var handler = ContributorAddedEvent;
			if (handler != null)
				handler (this, e);
		}
	}

}

