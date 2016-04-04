using System;
using System.Threading.Tasks;

namespace Core
{
	public interface ICache
	{
		Task<T> GetObject<T>(string key);

		Task InsertObject<T>(string key, T value);

		Task RemoveObject(string key);
	}
}