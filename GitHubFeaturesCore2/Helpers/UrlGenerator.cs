using GitHubFeaturesCore2.Models;
using Microsoft.Extensions.Options;

namespace GitHubFeaturesCore2.Helpers
{
    public class UrlGenerator : IUrlGenerator
    {
        private readonly GitHubOptions _githubOptions;

        public const string GITHUB_API_URL = @"https://api.github.com/";
        public const string GITHUB_REPO_URL = @"repos/{:owner}/{:repo}";
        public const string GITHUB_PULL_REQUESTS_URL = @"repos/{:owner}/{:repo}/pulls";
        public const string GITHUB_BRANCHES_URL = @"repos/{:owner}/{:repo}/branches";
        public const string GITHUB_COMMITS_URL = @"repos/{:owner}/{:repo}/commits";

        public UrlGenerator(IOptions<GitHubOptions> githubOptions)
        {
            _githubOptions = githubOptions.Value;
        }

        private string SetUpApiString(string apiString, string userName, string repoName)
        {
            var urlString = $"{GITHUB_API_URL}{apiString.Replace("{:owner}", userName).Replace("{:repo}", repoName)}";
            return $"{urlString}?client_id={_githubOptions.ClientId}&client_secret={_githubOptions.ClientSecret}";
        }

        public string GenerateUrlForGitHubApi(GitHubSettings settings)
        {
            var urlString = string.Empty;

            switch (settings.RequestType)
            {
                case RequestTypes.CheckIfRepositoryExists:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_REPO_URL, settings.UserName, settings.RepositoryName);
                    break;
                case RequestTypes.GetAllPullRequests:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_PULL_REQUESTS_URL, settings.UserName, settings.RepositoryName);
                    break;
                case RequestTypes.GetAllBranches:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_BRANCHES_URL, settings.UserName, settings.RepositoryName);
                    break;
                case RequestTypes.LastCommits:
                    if (!string.IsNullOrEmpty(settings.UserName) && !string.IsNullOrEmpty(settings.RepositoryName))
                        urlString = SetUpApiString(GITHUB_COMMITS_URL, settings.UserName, settings.RepositoryName);
                    break;
            }

            return urlString;
        }
    }
}
