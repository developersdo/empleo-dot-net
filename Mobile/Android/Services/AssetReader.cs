using System;
using System.Threading.Tasks;
using System.IO;
using Android;
using Android.Content;

namespace Core
{
	public class AssetReader : IAssetReader
	{
		Context _context;

		public AssetReader (IContextService contextService)
		{
			_context = (Context) contextService.GetContext();
		}

		public string ReadFileAsString(string fileName)
		{
			if(string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("fileName");

			string content = null;

			using (var sr = new StreamReader (_context.Assets.Open (fileName)))
			{
				content = sr.ReadToEnd ();
			}

			return content;
		}
	}
}
