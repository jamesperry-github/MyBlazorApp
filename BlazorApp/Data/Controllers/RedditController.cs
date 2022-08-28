using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using BlazorApp.Data.Models;
using static BlazorApp.Pages.Test;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlazorApp.Data.Controllers
{
    //private IEnumerable<GitHubBranch> branches = Array.Empty<GitHubBranch>();
    //private bool getBranchesError;
    //private bool shouldRender;

    //protected override bool ShouldRender() => shouldRender;

    //protected override async Task OnInitializedAsync()
    //{
    //    var request = new HttpRequestMessage(HttpMethod.Get,
    //        "https://www.reddit.com/r/wallstreetbets.json");
    //    request.Headers.Add("Accept", "application/vnd.github.v3+json");
    //    request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

    //    var client = ClientFactory.CreateClient();

    //    var response = await client.SendAsync(request);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        using var responseStream = await response.Content.ReadAsStreamAsync();
    //        branches = await JsonSerializer.DeserializeAsync
    //            <IEnumerable<GitHubBranch>>(responseStream);
    //    }
    //    else
    //    {
    //        getBranchesError = true;
    //    }

    //    shouldRender = true;
    //}
    public class RedditController
    {
        private string baseUrl = "https://www.reddit.com/";
        public async Task<List<RedditPost>> ScrapeSubReddit(string sub)
        {
            List<RedditPost> posts = new List<RedditPost>();
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}r/{sub}.json";
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = await response.Content.ReadAsStringAsync();
                    dynamic parsedResp = JObject.Parse(jsondata);
                    dynamic data = (JObject)parsedResp["data"];
                    dynamic children = (JArray)data["children"];
                    // each reddit post
                    foreach (var item in children)
                    {
                        //burp.Add(item["data"]["title"]);
                        posts.Add(
                            new RedditPost{
                            PostText = item["data"]["selftext"],
                            Title = item["data"]["title"],
                            Author = item["data"]["author"],
                            UpVotes = item["data"]["ups"],
                            NumAwards = item["data"]["total_awards_received"],
                            UpDownVoteRatio = item["data"]["score"],
                            NumComments = item["data"]["num_comments"]
                            });
                    }
                }
            }
            return await Task.FromResult(posts);
        }
    }
}