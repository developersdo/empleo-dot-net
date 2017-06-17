using System;
using System.Threading.Tasks;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace APIs
{

	public class HttpProxy : IProxy
	{
		public HttpProxy ()
		{
		}

		async Task<T> Get<T>(string url, CancellationToken cancellationToken = default(CancellationToken))
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Constants.Endpoint);

				var result = await client.GetAsync(url, cancellationToken);

				return await result.GetValue<T>();
			}
		}

		public async Task<WebResult<TReturn>> Get<TReturn>
		(	string endpoint,
			Method method,
			List<Parameter> parameters = null,
			CancellationToken token = default(CancellationToken))
		{
			if(endpoint == null)
				throw new ArgumentNullException("endpoint");

			if(parameters != null)
				endpoint = $"{endpoint}?{GetFinalResult(parameters)}";
			
			var result = await Get<TReturn>(endpoint, token);

			return new WebResult<TReturn>
			{
				Result = result
			};
		}

		string GetFinalResult (List<Parameter> parameters)
		{
			var result = new StringBuilder();

			foreach(Parameter parameter in parameters)
			{
				var property = parameter.Property;

				var value = parameter.Value;

				string output = $"{property}={value}&";

				result.Append(output);
			}

			var query = result.ToString();

			if(query.EndsWith("&"))
				query = query.TrimEnd('&');

			return query;
		}
	}
}