using System;
using System.Threading.Tasks;
using Core;
using Android.Content;

namespace Android
{
	public class EmailService : IEmailService
	{
		public void SendEmail(string destination, string subject)
		{
			Intent emailIntent = new Intent(Intent.ActionSendto);

			emailIntent.SetData(Android.Net.Uri.Parse("mailto:" + destination));

			emailIntent.PutExtra (Intent.ExtraSubject, subject);

			AppCompatActivityBase.CurrentActivity.StartActivity(Intent.CreateChooser(emailIntent, "Send mail..."));
		}
	}
}

