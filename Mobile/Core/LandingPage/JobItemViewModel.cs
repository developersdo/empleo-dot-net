using System;

namespace Android.ViewModels
{
	public class JobItemViewModel
	{
		public string Title { get; set; }
		public string CompanyName { get; set; }
		public string Location { get; set; }
		public bool IsRemote { get; set; }
		public string Category { get; set; }
	}
}