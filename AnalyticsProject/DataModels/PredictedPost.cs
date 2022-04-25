using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.DataModels
{
    // The prediction object stored in the database
    public class PredictedPost
    {
        public Guid Id { get; set; }
        public DateTimeOffset postDate { get; set; } // DateTimeOffset is date time object in C# 
        public string postContent { get; set; }
        public string platform { get; set; }
        public string postTime { get; set; }
        public int predictedLikes { get; set; }
        public int predictedRetweets { get; set; }
    }
}
