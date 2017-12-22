using System.Threading.Tasks;

namespace GitHubFeaturesCore2.Services
{
    public interface ICSharpCompile
    {
        Task<string> GetCodeResultAsync(string code);
    }
}
