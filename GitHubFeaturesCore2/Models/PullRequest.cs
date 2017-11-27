using Newtonsoft.Json;
using System.Collections.Generic;

namespace GitHubFeaturesCore2.Models
{
    public partial class PullRequest
    {
        [JsonProperty("base")]
        public PullRequestInfo Base { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("head")]
        public PullRequestInfo Head { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        public object MergedAt { get; set; }

        [JsonProperty("milestone")]
        public object Milestone { get; set; }

        [JsonProperty("requested_reviewers")]
        public List<Owner> RequestedReviewers { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("user")]
        public Owner User { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("comments")]
        public Comments Comments { get; set; }

        [JsonProperty("commits")]
        public Comments Commits { get; set; }

        [JsonProperty("html")]
        public Comments Html { get; set; }
    }

    public partial class Comments
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class PullRequestInfo
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("repo")]
        public Repository Repo { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("user")]
        public Owner User { get; set; }
    }

    public partial class PullRequest
    {
        public static List<PullRequest> FromJson(string json) => JsonConvert.DeserializeObject<List<PullRequest>>(json, ConverterPullRequest.Settings);
    }

    public static class SerializePullRequest
    {
        public static string ToJson(this List<PullRequest> self) => JsonConvert.SerializeObject(self, ConverterPullRequest.Settings);
    }

    public class ConverterPullRequest
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
