using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core
{
	public class MobileConfigurationManager : IMobileConfigurationManager
	{
		IAssetReader _assetReader;

		public MobileConfig MobileConfigurationFile {
			get;
			set;
		}

		public MobileConfigurationManager (IAssetReader assetReader)
		{
			_assetReader = assetReader;

			Init();
		}

		void Init ()
		{
			var jsonContent = _assetReader.ReadFileAsString(Keys.MobileConfigFileName);

			MobileConfigurationFile = JsonConvert.DeserializeObject<MobileConfig>(jsonContent);
		}
	}
}
