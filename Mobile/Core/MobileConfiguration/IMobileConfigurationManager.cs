using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core
{
	public interface IMobileConfigurationManager
	{
		MobileConfig MobileConfigurationFile { get; set; }
	}

}