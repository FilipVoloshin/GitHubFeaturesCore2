using GitHubFeaturesCore2.Models;
using System.Collections.Generic;

namespace GitHubFeaturesCore2.Services
{
    public interface IGithubService
    {
        Repository ProcessRepositoryInfoByUrl(string urlString);
        IList<PullRequest> ProcessPullRequests(string url);
        IList<Branch> ProcessBranches(string url);
        IList<Commit> ProcessCommits(string url);
    }
}
