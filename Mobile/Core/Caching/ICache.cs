using System;
using System.Threading.Tasks;

namespace Core
{
	public interface ICache
	{
		Task<T> GetObject<T>(string key);

		Task InsertObject<T>(string key, T value, DateTimeOffset? expiration = default(DateTimeOffset?));

		Task RemoveObject(string key);
	}
}