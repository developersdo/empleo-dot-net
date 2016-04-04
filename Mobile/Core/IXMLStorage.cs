using System;
using System.Threading.Tasks;

namespace Android
{
	public interface IXMLStorage
	{
		Task SaveStringAsync(string key, string content);

		Task<string> ReadStringAsync(string key, string defaultValue = "");
	}

}