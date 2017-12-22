using System;

namespace GitHubFeaturesCore2.Helpers
{
    public class ResultChecker : IResultChecker
    {
        public bool IsCodeCorrect(string code, object expectedResult)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(code))
            {
                if (expectedResult != null)
                {
                    result = string.Equals(code, expectedResult.ToString(), StringComparison.OrdinalIgnoreCase);
                }
            }
            return result;
        }
    }
}
