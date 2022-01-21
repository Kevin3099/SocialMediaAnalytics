using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class TwitterSummaryVM
    {
        [Required]
        public Guid Id { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public int CountOfPosts { get; set; }
        public int totalLikes { get; set; }
        public int totalRetweets { get; set; }
        public int totalComments { get; set; }
        public int averageLikes { get; set; }
        public int averageRetweets { get; set; }
        public int averageComments { get; set; }
        public int followerIncrease { get; set; }
        public int totalFollowers { get; set; }
        public TwitterSummaryVM()
        {
        }

        public TwitterSummaryVM(TwitterSummary twitter)
        {
            Id = twitter.Id;
            DateFrom = twitter.DateFrom;
            DateTo = twitter.DateTo;
            CountOfPosts = twitter.CountOfPosts;
            totalLikes = twitter.totalLikes;
            totalRetweets = twitter.totalRetweets;
            totalComments = twitter.totalComments;
            totalFollowers = twitter.totalFollowers;
            followerIncrease = twitter.followerIncrease;
            averageLikes = twitter.averageLikes;
            averageRetweets = twitter.averageRetweets;
            averageComments = twitter.averageComments;
        }
    }
}
