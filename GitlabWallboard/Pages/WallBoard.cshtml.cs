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

        private string pat = "";
        private string project = "4701217";

        static HttpClient client = new HttpClient();

        public void OnGet()
        {
            GitlabIssues = GetIssuesAsync().Result;
        }

        public async Task<List<GitLabIssues>> GetIssuesAsync()
        {
            string api = "https://gitlab.com/api/v4/projects/" + project + "/issues";

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