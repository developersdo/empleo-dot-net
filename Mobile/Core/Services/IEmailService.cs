using System;
using System.Threading.Tasks;

namespace Core
{
	public interface IEmailService
	{
		void SendEmail(string destination, string subject);
	}
}

