using System;
using Android.Content;
using System.Threading.Tasks;

namespace Android
{
	public class XMLStorage : IXMLStorage
	{
		Context _contextService;

		ISharedPreferences _sharedPreference;

		public XMLStorage (IContextService contextService)
		{
			_contextService = (Context) contextService.GetContext();

			_sharedPreference = _contextService.GetSharedPreferences(Extras.SHARED_PREFERENCE_NAME, FileCreationMode.Private);
		}

		public async Task SaveStringAsync (string key, string content)
		{
			await Task.Run(()=>
				{
					_sharedPreference
						.Edit()
						.PutString(key, content)
						.Apply();	
				});
		}

		public async Task<string> ReadStringAsync (string key, string defaultValue = "")
		{
			return await Task.Run<string>(()=>
				{
					return _sharedPreference.GetString(key, defaultValue);
				});
		}
	}
}