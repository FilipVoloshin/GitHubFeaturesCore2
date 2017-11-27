using System.ComponentModel.DataAnnotations;

namespace GitHubFeaturesCore2.Models
{
    public class GitHubInformationForm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string RepositoryName { get; set; }
    }
}
