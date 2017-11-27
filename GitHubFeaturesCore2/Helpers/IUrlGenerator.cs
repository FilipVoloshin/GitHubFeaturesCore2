using GitHubFeaturesCore2.Models;

namespace GitHubFeaturesCore2.Helpers
{
    public interface IUrlGenerator
    {
        string GenerateUrlForGitHubApi(GitHubSettings settings);
    }
}
