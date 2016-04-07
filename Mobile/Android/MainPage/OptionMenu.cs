using System;

namespace Android
{
	public class OptionMenu
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public ShowAs ShowAs { get; set; }

		public Action OnSelected { get; set; }
	}
}

