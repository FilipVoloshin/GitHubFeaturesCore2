using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubFeaturesCore2.Services;
using GitHubFeaturesCore2.Helpers;

namespace GitHubFeaturesCore2.Controllers
{
    public class CSharpCompileController : Controller
    {

        private ICSharpCompile sharpCompile;
        private IResultChecker resultChecker;
        public CSharpCompileController(ICSharpCompile sharpCompile, IResultChecker resultChecker)
        {
            this.sharpCompile = sharpCompile;
            this.resultChecker = resultChecker;
        }
        public IActionResult Index()
        {
            ViewBag.Main = $"using System;{Environment.NewLine}{Environment.NewLine}public class Test{Environment.NewLine}{{{Environment.NewLine}\t" +
                        $"public static void Main(){Environment.NewLine}\t{{{Environment.NewLine}\t}}{Environment.NewLine}}}";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetCodeResult(string codePart)
        {
            var codeResult = await sharpCompile.GetCodeResultAsync(codePart);
            var isSuccess = resultChecker.IsCodeCorrect(codeResult, "Hello world");
            ViewBag.Result = codeResult;
            ViewBag.Success = isSuccess;
            return PartialView("_CodeResult");
        }
    }
}