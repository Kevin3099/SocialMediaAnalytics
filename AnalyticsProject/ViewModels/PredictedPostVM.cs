using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class PredictedPostVM
    {
        public DateTimeOffset postDate { get; set; }
        public string postContent { get; set; }
        public string platform { get; set; }
        public string postTime { get; set; }
        public int predictedLikes { get; set; }
        public int predictedRetweets { get; set; }

        public PredictedPostVM(PredictedPost predictedPost)
        {
            postDate = predictedPost.postDate;
            postContent = predictedPost.postContent;
            platform = predictedPost.platform;
            postTime = predictedPost.postTime;
            predictedLikes = predictedPost.predictedLikes;
            predictedRetweets = predictedPost.predictedRetweets;

        }
    }
}
