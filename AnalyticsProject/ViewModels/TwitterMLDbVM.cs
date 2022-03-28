using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class TwitterMLDbVM
    {
        public Guid Id { get; set; }
        public string user { get; set; }
        public DateTimeOffset postDate { get; set; }
        public string postContent { get; set; }
        public string platform { get; set; }
        public string postTime { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }

        public TwitterMLDbVM(TwitterMLDb twitter)
        {
            user = twitter.user;
            postDate = twitter.postDate;
            postContent = twitter.postContent;
            platform = twitter.platform;
            postTime = twitter.postTime;
            likes = twitter.likes;
            retweets = twitter.retweets;

        }
    }
}
