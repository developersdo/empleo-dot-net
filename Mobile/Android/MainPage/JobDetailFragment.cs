using System;
using Android.Support.V7.App;
using Android.OS;
using Android.Support.V4.App;
using Api.Contract;
using Microsoft.Practices.ServiceLocation;

namespace Android
{
	public class JobDetailFragment : Fragment, IBackPressed
	{
		string _jobDetail;

		JobDetailFragmentViewModel _viewModel;

		public JobDetailFragment (string jobDetail)
		{
			_jobDetail = jobDetail;
		}

		public override async void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			GetServices();

			await _viewModel.Init(_jobDetail);
		}

		void GetServices ()
		{
			_viewModel = ServiceLocator.Current.GetInstance<JobDetailFragmentViewModel>();
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.JobDetailActivityLayout, container, false);
		}

		public bool OnBackPressed ()
		{
			return new BackPressImpl(this).OnBackPressed();
		}
	}
}

