using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace GitlabWallboard.Pages
{
    public class WallBoardModel : PageModel
    {
        private string pat = "";
        private string api = "https://gitlab.example.com/api/v4/";
        private string area = "projects/";
        private string item = "/issues/";
        private string project = "";

        public void OnGet()
        {
            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri(api);
            //client.DefaultRequestHeaders.Accept.Add("PRIVATE-TOKEN: " + pat);

            project = "idle-adventures";

            var encodedUrl = api + area + project + item;

            RestClient _restClient = new RestClient();

            RestRequest request =
                new RestRequest($@"projects/idle-adventures/issues", Method.GET);

            request.Parameters.Clear();

            _restClient.BaseUrl = new Uri(api);
            //request.Parameters.Add(new Parameter()
            //{
            //    Name = "application/json",
            //    ContentType = "application/json",
            //    Type = ParameterType.RequestBody,
            //    Value = commit
            //});
            request.Parameters.Add(new Parameter()
            {
                Name = "PRIVATE-TOKEN",
                Type = ParameterType.HttpHeader,
                Value = pat
            });

            IRestResponse response = _restClient.Execute(request);

            var requfest = "test";

            //request.ContentType = "application/json";

            //request.Headers.Add("PRIVATE-TOKEN:", pat);

            //using (System.IO.Stream s = request.GetResponse().GetResponseStream())
            //{
            //    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
            //    {
            //        var jsonResponse = sr.ReadToEnd();
            //        Console.WriteLine(String.Format("Response: {0}", jsonResponse));
            //    }
            //}
        }
    }
}