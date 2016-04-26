using System;
using Android.Support.V7.App;
using Android.OS;
using Android.Widget;
using Android.Support.V4.App;
using Api.Contract;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Helpers;
using Android.Views;
using System.Collections.Generic;

namespace Android
{
	public class JobDetailFragment : Fragment, IBackPressed
	{
		string _jobDetail;

		public ImageView _companyIcon;

		public TextView _companyName;

		public TextView _isRemote;

		public TextView _type;

		public TextView _location;

		public TextView _visitors;

		public TextView _description;

		public Button _sendCV;

		public JobDetailFragmentViewModel _viewModel { get; set; }

		Binding<bool, ViewStates> remoteBinding;

		List<Binding<string, string>> bindings;

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

		void Init(){
			bindings = new List<Binding<string, string>> ();
		}

		void SetBindings ()
		{
			remoteBinding = this.SetBinding(() => _viewModel.IsRemote, _isRemote, () => _isRemote.Visibility, BindingMode.OneWay).ConvertSourceToTarget(Converters.BoolToVisibilityReverseConverter);

			bindings.Add(this.SetBinding(() => _viewModel.JobType, _type, () => _type.Text, BindingMode.OneWay));

			bindings.Add(this.SetBinding(() => _viewModel.JobDescription, _description, () => _description.Text, BindingMode.OneWay));

			bindings.Add(this.SetBinding(() => _viewModel.CompanyName, _companyName, () => _companyName.Text, BindingMode.OneWay));

			bindings.Add(this.SetBinding(() => _viewModel.Location, _location, () => _location.Text, BindingMode.OneWay));

			bindings.Add(this.SetBinding(() => _viewModel.Visits, _visitors, () => _visitors.Text, BindingMode.OneWay));

			_sendCV.SetCommand ("Click", _viewModel.SendCVCommand);

		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			Init ();

			SetBindings ();
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.JobDetailActivityLayout, container, false);

			_companyIcon = view.FindViewById<ImageView> (Resource.Id.companyIcon);

			_companyName = view.FindViewById<TextView> (Resource.Id.companyName);

			_isRemote = view.FindViewById<TextView> (Resource.Id.isRemote);

			_type = view.FindViewById<TextView> (Resource.Id.type);

			_location = view.FindViewById<TextView> (Resource.Id.location);

			_visitors = view.FindViewById<TextView> (Resource.Id.visitors);

			_description = view.FindViewById<TextView> (Resource.Id.jobDescription);

			_sendCV = view.FindViewById<Button> (Resource.Id.sendCV);

			return view;
		}

		public bool OnBackPressed ()
		{
			return new BackPressImpl(this).OnBackPressed();
		}

		public override void OnDestroy ()
		{
			base.OnDestroy ();

			remoteBinding.Detach ();

			foreach(var bind in bindings)
				bind.Detach();
		}
	}
}
