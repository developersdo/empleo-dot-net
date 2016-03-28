using System;
using Android.Support.V4.App;

namespace Android
{

	public class BackPressImpl : IBackPressed {

		private Fragment _parentFragment;

		public BackPressImpl(Fragment parentFragment) {
			
			_parentFragment = parentFragment;
		}

		public bool OnBackPressed() {

			if (_parentFragment == null) return false;

			int childCount = _parentFragment.ChildFragmentManager.BackStackEntryCount;

			if (childCount == 0) {
				return false;

			} else 
			{
				var childFragmentManager = _parentFragment.ChildFragmentManager;

				var childFragment = (IBackPressed) childFragmentManager.Fragments[0];

				if (!childFragment.OnBackPressed()) 
				{	
					childFragmentManager.PopBackStackImmediate();
				}
				return true;
			}
		}
	}
}
