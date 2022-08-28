using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BlazorApp.Data.Controllers
{
    public class RedditController
    {
        public async void /*Task<ActionResult>*/ /*Task<HttpResponseMessage>*/ GetCustomers()
        {
            using (var client = new HttpClient())
            {
                string url = "https://www.reddit.com/r/wallstreetbets.json";
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
                    dynamic childData = (JObject)children[0]["data"];
                    string subreddit = childData["subreddit"].ToString();
                    //JArray array = (JArray)ojObject["chats"];
                    //int id = Convert.ToInt32(array[0].toString());
                    Console.WriteLine("derp");
                    //return Content(jsondata, "application/json");
                }
                //return Json(1, JsonRequestBehavior.AllowGet);
            }
        }
    }
    //public class RedditController
    //{
    //    private readonly ApplicationDbContext _context;
    //    //
    //    private IEnumerable<GitHubBranch> branches = Array.Empty<GitHubBranch>();
    //    private bool getBranchesError;
    //    private bool shouldRender;
    //    //protected override bool ShouldRender() => shouldRender;
    //    //

    //    public RedditController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    //public List<test> best()
    //    //{
    //    //    return _context.test.ToList();
    //    //}

    //    public async void tester()
    //    {
    //        var request = new HttpRequestMessage(HttpMethod.Get,
    //        "https://www.reddit.com/r/wallstreetbets.json");
    //        request.Headers.Add("Accept", "application/vnd.github.v3+json");
    //        request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

    //        var client = IHttpClientFactory.CreateClient();

    //        var response = await client.SendAsync(request);

    //        //if (response.IsSuccessStatusCode)
    //        //{
    //        //    using var responseStream = await response.Content.ReadAsStreamAsync();
    //        //    branches = await JsonSerializer.DeserializeAsync
    //        //        <IEnumerable<GitHubBranch>>(responseStream);
    //        //}
    //        //else
    //        //{
    //        //    getBranchesError = true;
    //        //}

    //        //shouldRender = true;
    //    }
    //}

    //public class GitHubBranch
    //{
    //    [JsonPropertyName("name")]
    //    public string Name { get; set; }
    //}
}
