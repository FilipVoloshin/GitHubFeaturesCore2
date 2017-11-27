namespace GitHubFeaturesCore2.Models
{
    public enum RequestTypes
    {
        CheckIfRepositoryExists = 0,
        GetAllPullRequests,
        GetAllBranches,
        LastCommits
    }

    public class GitHubSettings
    {
        public string UserName { get; set; }
        public string RepositoryName { get; set; }
        public RequestTypes RequestType { get; set; }
    }
}
