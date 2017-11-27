using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitHubFeaturesCore2.Models;
using GitHubFeaturesCore2.Services;
using GitHubFeaturesCore2.Helpers;

namespace GitHubFeaturesCore2.Controllers
{
    public class HomeController : Controller
    {
        private IUrlGenerator _urlGenerator;
        private IGithubService _githubService;
        public HomeController(IUrlGenerator urlGenerator, IGithubService githubService)
        {
            _urlGenerator = urlGenerator;
            _githubService = githubService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckRepository(GitHubInformationForm form, RequestTypes request)
        {
            Repository repositoryInformation = null;
            var url = string.Empty;

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    repositoryInformation = _githubService.ProcessRepositoryInfoByUrl(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }

            return PartialView("_Repository", repositoryInformation);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckPullRequests(GitHubInformationForm form, RequestTypes request)
        {
            var url = string.Empty;
            IList<PullRequest> pullRequests = new List<PullRequest>();

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    pullRequests = _githubService.ProcessPullRequests(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }
            return PartialView("_PullRequests", pullRequests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckBranches(GitHubInformationForm form, RequestTypes request)
        {
            IList<Branch> branches = new List<Branch>();
            var url = string.Empty;

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    branches = _githubService.ProcessBranches(url);
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }
            return PartialView("_Branches", branches);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckCommits(GitHubInformationForm form, RequestTypes request)
        {
            var commintsNumber = 10;
            IList<Commit> commits = new List<Commit>();
            var url = string.Empty;

            if (!string.IsNullOrEmpty(form.UserName) && !string.IsNullOrEmpty(form.RepositoryName))
            {
                var gihubSettings = new GitHubSettings { UserName = form.UserName, RepositoryName = form.RepositoryName, RequestType = request };
                url = _urlGenerator.GenerateUrlForGitHubApi(gihubSettings);
                try
                {
                    commits = _githubService.ProcessCommits(url);
                    if (commits.Any())
                    {
                        commits = commits.OrderByDescending(c => c.PurpleCommit.Committer.DateOfCommit).Take(commintsNumber).ToList();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.InnerException = ex.Message;
                }
            }

            return PartialView("_Commits", commits);
        }
    }
}