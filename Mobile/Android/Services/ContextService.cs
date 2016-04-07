using System;
using Android.Content.Res;

namespace Android
{

	public class ContextService : IContextService
	{
		public object GetContext ()
		{
			return EmpleadoApp.AppContext;
		}
	}
}
