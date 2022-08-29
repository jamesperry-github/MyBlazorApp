using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Controllers
{
    public class RedditController
    {
        private string baseUrl = "https://www.reddit.com/";
        public async Task<List<RedditPost>> ScrapeSubReddit(string sub)
        {
            List<RedditPost> posts = new List<RedditPost>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{baseUrl}r/{sub}.json?limit=100";
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
                            posts.Add(new RedditPost
                            {
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
            }
            catch (Exception)
            {
                throw;
            }
            return await Task.FromResult(posts);
        }
        public int FindCount(List<RedditPost> list, string searchTerm)
        {
            int counter = 0;
            foreach (var item in list)
            {
                bool res = CheckString(item.Title, searchTerm);
                if(res)
                {
                    counter++;
                }
            }
            return counter;
        }
        public bool CheckString(string stringValue, string anotherStringValue)
        {
            if (stringValue.Contains(anotherStringValue))
            {
                return true;
            }
            return false;
        }
    }
}