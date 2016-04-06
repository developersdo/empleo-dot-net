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
using Microsoft.Practices.ServiceLocation;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using GalaSoft.MvvmLight.Helpers;
using Core;
using Android.Activities;
using Android.Text.Method;

namespace Android
{
	[Activity (Label = "Agradecimientos", Theme="@style/AppTheme", ParentActivity = typeof(MainPageActivity))]
	public class AboutActivity : AppCompatActivityBase
	{
		LinearLayout _contributors;

		V7Toolbar _toolBar;

		AboutViewModel _viewModel;

		TextView _howToCollaborate;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView(Resource.Layout.AboutLayout);

			GetReferences();

			GetServices();

			InitActionBar();

			Init();
		}

		void InitActionBar ()
		{
			SetSupportActionBar(_toolBar);

			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			_viewModel.OnResume();
		}

		void GetReferences ()
		{
			_contributors = FindViewById<LinearLayout> (Resource.Id.contributors);

			_toolBar = FindViewById<V7Toolbar> (Resource.Id.MainToolbar);

			_howToCollaborate = FindViewById<TextView> (Resource.Id.howtocollaborate);
		}

		void GetServices ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<AboutViewModel>();
		}

		void Init ()
		{
			_contributors.SetScrollContainer(false);

			_viewModel.ContributorAddedEvent += OnContributorAdded;;
		}

		void OnContributorAdded (object sender, ContributorAddedEventHandler e)
		{
			var model = e.User;

			var view = LayoutInflater.Inflate(Resource.Layout.ContributorItem, null);

			var image = view.FindViewById<ImageView>(Resource.Id.image);

			var name = view.FindViewById<TextView>(Resource.Id.name);

			var pullRequest = view.FindViewById<TextView>(Resource.Id.pr);

			name.Text = model.UserName;

			pullRequest.Text = string.Format(GetString(Resource.String.PullRequestSubmitedContributors), model.MergedPullRequest);

			_contributors.AddView(view);
		}
	}
}

