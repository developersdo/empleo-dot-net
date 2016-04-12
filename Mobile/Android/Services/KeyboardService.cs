using System;
using Core;
using Android.Views.InputMethods;
using Android.Content;
using Android.Views;

namespace Android
{
	public class KeyboardService : IKeyboardService
	{
		InputMethodManager _inputMethodManager;

		IContextService _contextService;

		public KeyboardService (IContextService contextService)
		{
			_contextService = contextService;

			_inputMethodManager = 
				((Context)_contextService.GetContext ()).GetSystemService (Context.InputMethodService) as InputMethodManager;
		}

		public void ShowKeyboard (object focusOver)
		{
			if(focusOver == null)
				throw new ArgumentNullException("focusOver");

			var focus = (View) focusOver;

			_inputMethodManager.ShowSoftInput(focus, ShowFlags.Forced);

			_inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
		}
	}
}

