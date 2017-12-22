namespace GitHubFeaturesCore2.Helpers
{
    public interface IResultChecker
    {
        bool IsCodeCorrect(string code, object expectedResult);
    }
}
