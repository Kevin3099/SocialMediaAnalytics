using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.DataModels
{
    // Twitter Data Object for Predictions
    public class TwitterMLDb
    {
        public Guid Id { get; set; }
        public string user { get; set; }
        public DateTimeOffset postDate { get; set; }
        public string postContent { get; set; }
        public string platform { get; set; }
        public string postTime { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }
    }
}
