using GitHubFeaturesCore2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHubFeaturesCore2.Services
{

    public class GitHubService : IGithubService
    {
        HttpClient client;

        public GitHubService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public Repository ProcessRepositoryInfoByUrl(string urlString)
        {
            Repository repository = null;
            try
            {
                if (!string.IsNullOrEmpty(urlString))
                {
                    var stringTask = client.GetStringAsync(urlString).Result;

                    repository = Repository.FromJson(stringTask);
                }
                return repository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<PullRequest> ProcessPullRequests(string urlString)
        {
            IList<PullRequest> pullRequests = new List<PullRequest>();

            try
            {
                if (!string.IsNullOrEmpty(urlString))
                {
                    var stringTask = client.GetStringAsync(urlString).Result;

                    pullRequests = PullRequest.FromJson(stringTask);
                }

                return pullRequests;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Branch> ProcessBranches(string urlString)
        {
            IList<Branch> branches = new List<Branch>();

            try
            {
                if (!string.IsNullOrEmpty(urlString))
                {
                    var stringTask = client.GetStringAsync(urlString).Result;

                    branches = Branch.FromJson(stringTask);
                }

                return branches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Commit> ProcessCommits(string urlString)
        {
            IList<Commit> commits = new List<Commit>();

            try
            {
                if (!string.IsNullOrEmpty(urlString))
                {
                    var stringTask = client.GetStringAsync(urlString).Result;

                    commits = Commit.FromJson(stringTask);
                }

                return commits;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
