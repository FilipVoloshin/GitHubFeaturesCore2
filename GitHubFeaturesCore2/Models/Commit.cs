using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GitHubFeaturesCore2.Models
{
    public partial class Commit
    {
        [JsonProperty("author")]
        public FluffyAuthor Author { get; set; }

        [JsonProperty("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonProperty("committer")]
        public FluffyAuthor Committer { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("parents")]
        public List<Parent> Parents { get; set; }

        [JsonProperty("commit")]
        public PurpleCommit PurpleCommit { get; set; }
    }

    public partial class PurpleCommit
    {
        [JsonProperty("author")]
        public PurpleAuthor Author { get; set; }

        [JsonProperty("comment_count")]
        public long CommentCount { get; set; }

        [JsonProperty("committer")]
        public PurpleAuthor Committer { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("tree")]
        public Tree Tree { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("verification")]
        public Verification Verification { get; set; }
    }

    public partial class Verification
    {
        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }
    }

    public partial class Tree
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class PurpleAuthor
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        public DateTime? DateOfCommit { get { return DateTime.Parse(this.Date, null, System.Globalization.DateTimeStyles.RoundtripKind); } }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Parent
    {
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class FluffyAuthor
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("followers_url")]
        public string FollowersUrl { get; set; }

        [JsonProperty("following_url")]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url")]
        public string GistsUrl { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("organizations_url")]
        public string OrganizationsUrl { get; set; }

        [JsonProperty("received_events_url")]
        public string ReceivedEventsUrl { get; set; }

        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }

        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }

        [JsonProperty("starred_url")]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url")]
        public string SubscriptionsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Commit
    {
        public static List<Commit> FromJson(string json) => JsonConvert.DeserializeObject<List<Commit>>(json, ConverterCommit.Settings);
    }

    public static class SerializeCommit
    {
        public static string ToJson(this List<Commit> self) => JsonConvert.SerializeObject(self, ConverterCommit.Settings);
    }

    public class ConverterCommit
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
