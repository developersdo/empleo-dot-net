using System;
using System.Collections.Generic;
using Octokit;
using System.Threading.Tasks;
using System.Linq;

namespace Core
{
	public class OctocatContributorService : IGithubContributorService
	{
		IMobileConfigurationManager _mobileConfigService;

		readonly string API_KEY;

		public OctocatContributorService (IMobileConfigurationManager mobileConfigService)
		{
			_mobileConfigService = mobileConfigService;

			API_KEY = _mobileConfigService.MobileConfigurationFile.GitHubKey;
		}

		public async Task<List<GithubUser>> GetAllContributors (string productHeaderValue, string owner, string projectName)
		{
			var pullRequest = await GetPullRequests(productHeaderValue, owner, projectName);

			var contributors = pullRequest.Where(x => x.MergedAt.HasValue)
				.GroupBy(x => x.User.Login)
				.Select(x => new { Key = x.Key, Count = x.Count() })
				.OrderByDescending(x => x.Count);

			var user = new List<GithubUser>();

			foreach(var userx in contributors)
			{
				user.Add(new GithubUser
					{
						UserName = userx.Key,
						MergedPullRequest = userx.Count
					});
			}

			return user;
		}

		async Task<IReadOnlyList<PullRequest>> GetPullRequests (string productHeaderValue,string owner, string projectName)
		{
			var github = new GitHubClient (new ProductHeaderValue (productHeaderValue));

			if(!string.IsNullOrEmpty(API_KEY))
				github.Credentials = new Credentials(API_KEY);

			var filter = new PullRequestRequest() { State = ItemState.Closed };

			return await github.Repository.PullRequest.GetAllForRepository(owner, projectName, filter);
		}
	}
}