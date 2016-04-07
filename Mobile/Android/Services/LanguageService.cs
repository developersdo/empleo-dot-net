using System;
using Android.Content.Res;
using Android.Content;

namespace Android
{

	public class LanguageService : ILanguageService
	{
		Resources _resource;

		string _packageName;

		public LanguageService (IContextService contextService)
		{
			var context = (Context) contextService.GetContext();

			_resource = context.Resources;

			_packageName = context.PackageName;
		}

		public string GetStringFor (string id)
		{
			int resId = _resource.GetIdentifier(id, "string", _packageName);

			return _resource.GetString(resId);
		}
	}
}
