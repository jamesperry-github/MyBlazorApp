namespace BlazorApp.Data.Models
{
    public class RedditPost
    {
        public string PostText  { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int UpVotes { get; set; }
        public int NumAwards { get; set; }
        public int UpDownVoteRatio { get; set; }
        public int NumComments { get; set; }

        public RedditPost()
        {

        }
    }
}
