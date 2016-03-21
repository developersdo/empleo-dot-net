using System;
using GalaSoft.MvvmLight.Views;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V7.App;

namespace Android
{
	public class AppCompatDialogService : IDialogService
	{
		public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
		{
			var afterHideCallbackWithResponse = (Action<bool>) (r =>
				{
					if (afterHideCallback == null)
						return;
					afterHideCallback();
					afterHideCallback = null;
				});

			var dialog = CreateDialog(message, title, buttonText, null, afterHideCallbackWithResponse);
			dialog.Dialog.Show();
			return dialog.Tcs.Task;
		}

		public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
		{
			var afterHideCallbackWithResponse = (Action<bool>)(r =>
				{
					if (afterHideCallback == null)
						return;
					afterHideCallback();
					afterHideCallback = null;
				});

			var dialog = CreateDialog(error.Message, title, buttonText, null, afterHideCallbackWithResponse);
			dialog.Dialog.Show();
			return dialog.Tcs.Task;
		}

		public Task ShowMessage(string message, string title)
		{
			var dialog = CreateDialog(message, title);
			dialog.Dialog.Show();
			return dialog.Tcs.Task;
		}

		public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
		{
			var afterHideCallbackWithResponse = (Action<bool>)(r =>
				{
					if (afterHideCallback == null)
						return;
					afterHideCallback();
					afterHideCallback = null;
				});

			var dialog = CreateDialog(message, title, buttonText, null, afterHideCallbackWithResponse);
			dialog.Dialog.Show();
			return dialog.Tcs.Task;
		}

		public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
		{
			var afterHideCallbackWithResponse = (Action<bool>)(r =>
				{
					if (afterHideCallback == null)
						return;
					afterHideCallback(r);
					afterHideCallback = null;
				});

			var dialog = CreateDialog(message, title, buttonConfirmText, buttonCancelText ?? "Cancel", afterHideCallbackWithResponse);
			dialog.Dialog.Show();
			return dialog.Tcs.Task;
		}

		public Task ShowMessageBox(string message, string title)
		{
			return ShowMessage(message, title);
		}

		private static AlertDialogInfo CreateDialog(string content, string title, string okText = null, string cancelText = null, Action<bool> afterHideCallbackWithResponse = null)
		{
			var tcs = new TaskCompletionSource<bool>();
			var builder = new AlertDialog.Builder(AppCompatActivityBase.CurrentActivity);
			builder.SetMessage(content);
			builder.SetTitle(title);
			var dialog = (AlertDialog)null;
			builder.SetPositiveButton(okText ?? "OK", (d, index) =>
				{
					tcs.TrySetResult(true);
					if (dialog != null)
					{
						dialog.Dismiss();
						dialog.Dispose();
					}
					if (afterHideCallbackWithResponse == null)
						return;
					afterHideCallbackWithResponse(true);
				});

			if (cancelText != null)
			{
				builder.SetNegativeButton(cancelText, (d, index) =>
					{
						tcs.TrySetResult(false);
						if (dialog != null)
						{
							dialog.Dismiss();
							dialog.Dispose();
						}
						if (afterHideCallbackWithResponse == null)
							return;
						afterHideCallbackWithResponse(false);
					});
			}

			builder.SetOnDismissListener(new OnDismissListener(() =>
				{
					tcs.TrySetResult(false);
					if (afterHideCallbackWithResponse == null)
						return;
					afterHideCallbackWithResponse(false);
				}));

			dialog = builder.Create();

			return new AlertDialogInfo
			{
				Dialog = dialog,
				Tcs = tcs
			};
		}

		private struct AlertDialogInfo
		{
			public AlertDialog Dialog;
			public TaskCompletionSource<bool> Tcs;
		}

		private sealed class OnDismissListener : Java.Lang.Object, IDialogInterfaceOnDismissListener
		{
			private readonly Action _action;

			public OnDismissListener(Action action)
			{
				_action = action;
			}

			public void OnDismiss(IDialogInterface dialog)
			{
				_action();
			}
		}
	}
}

