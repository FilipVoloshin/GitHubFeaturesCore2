using Newtonsoft.Json;

namespace GitHubFeaturesCore2.Models
{
    public partial class Repository
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("pulls_url")]
        public string PullsUrl { get; set; }

        [JsonProperty("pushed_at")]
        public string PushedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("watchers_count")]
        public long WatchersCount { get; set; }
    }

    public partial class Repository
    {
        public static Repository FromJson(string json) => JsonConvert.DeserializeObject<Repository>(json, ConverterSepository.Settings);
    }

    public static class SerializeRepository
    {
        public static string ToJson(this Repository self) => JsonConvert.SerializeObject(self, ConverterSepository.Settings);
    }

    public class ConverterSepository
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
