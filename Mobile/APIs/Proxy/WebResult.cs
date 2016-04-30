using System;
using System.Threading.Tasks;
using System.Net;

namespace APIs
{
	public class WebResult<TData>
	{
		public TData Result { get; set; }
	}

}