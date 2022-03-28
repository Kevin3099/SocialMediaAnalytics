using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.DataModels
{
    public class TwitterMLDb
    {
        public string user { get; set; }
        public DateTimeOffset postDate { get; set; }
        public string postContent { get; set; }
        public string platform { get; set; }
        public string postTime { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }
    }
}
