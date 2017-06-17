using System;
using Core;
using System.Reactive.Linq;
using Akavache;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Android
{
	public class Cache : ICache
	{
		public Cache()
		{
			BlobCache.ApplicationName = EmpleadoApp.AppContext.PackageName;
		}

		public async Task RemoveObject(string key)
		{
			await BlobCache.UserAccount.Invalidate(key);
		}

		public async Task<T> GetObject<T>(string key)
		{
			try
			{
				return await BlobCache.UserAccount.GetObject<T>(key);
			}
			catch (KeyNotFoundException)
			{
				return default(T);
			}
		}

		public async Task InsertObject<T>(string key, T value, DateTimeOffset? expiration = default(DateTimeOffset?))
		{
			await BlobCache.UserAccount.InsertObject(key, value, expiration);
		}
	}
}

