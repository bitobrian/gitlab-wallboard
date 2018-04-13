using Flurl;
using Flurl.Http;
using GitlabWallboard.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GitlabWallboard.Pages
{
    public class WallBoardModel : PageModel
    {
        public List<GitLabIssues> GitlabIssues { get; set; }
        public string Message { get; set; }

        static HttpClient client = new HttpClient();

        public void OnGet()
        {

        }

        public void OnPostView(string pat, string pid)
        {
            LoadBoard(pat, pid);
        }

        private void LoadBoard(string pat, string pid)
        {
            if (GitlabIssues != null)
                RefreshBoard();
            GitlabIssues = GetIssuesAsync(pat,pid).Result;
        }

        private void RefreshBoard()
        {
        }

        public async Task<List<GitLabIssues>> GetIssuesAsync(string pat, string pid)
        {
            string api = "https://gitlab.com/api/v4/projects/" + pid + "/issues";

            client.BaseAddress = new Uri(api);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", pat);

            
            string product = await GetIssuesAsync(api);

            var gitLabIssues = GitLabIssues.FromJson(product);

            return gitLabIssues;
        }

        static async Task<string> GetIssuesAsync(string path)
        {
            string product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsStringAsync();
            }
            return product;
        }
    }
}