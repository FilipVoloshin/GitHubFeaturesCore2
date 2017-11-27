using Newtonsoft.Json;
using System.Collections.Generic;

namespace GitHubFeaturesCore2.Models
{
    public partial class Branch
    {
        [JsonProperty("commit")]
        public Commit Commit { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Commit
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Branch
    {
        public static List<Branch> FromJson(string json) => JsonConvert.DeserializeObject<List<Branch>>(json, ConverterBranch.Settings);
    }

    public static class SerializeBranch
    {
        public static string ToJson(this List<Branch> self) => JsonConvert.SerializeObject(self, ConverterBranch.Settings);
    }

    public class ConverterBranch
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
