using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace APIs
{
	public static class HttpResultMessageExtensions
	{
		public static async Task<T> GetValue<T>(this HttpResponseMessage msg)
		{
			if (msg == null || msg.Content == null)
				return default(T);
			
			var value = await msg.Content.ReadAsStringAsync();

			var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);

			return result;
		}
	}
}

