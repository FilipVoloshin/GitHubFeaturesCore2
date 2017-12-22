namespace GitHubFeaturesCore2.Models
{
    public class HttpTestRequest
    {
        public string Url { get; set; }
        public string Body { get; set; }
    }

    //Model for the request / input
    public class CodeRequest
    {
        public string Language { get; set; }
        public bool CaptureStats { get; set; }
        public string[] Sources { get; set; }
    }

    //Model for the response / output
    public class CodeResponse
    {
        public string Phase { get; set; }
        public string Reason { get; set; }
        public bool Succeeded { get; set; }
        public string[] Output { get; set; }
    }
}
