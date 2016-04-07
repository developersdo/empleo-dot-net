using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
	public interface IGithubContributorService
	{
		Task<List<GithubUser>> GetAllContributors(string productHeaderValue, string userName, string projectName);
	}
}