using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class FacebookSummaryVM
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
        public FacebookSummaryVM()
        {
        }

        public FacebookSummaryVM(FacebookSummary fb)
        {
            Id = fb.Id;
            DateFrom = fb.DateFrom;
            DateTo = fb.DateTo;
            CountOfPosts = fb.CountOfPosts;
            totalLikes = fb.totalLikes;
            totalRetweets = fb.totalRetweets;
            totalComments = fb.totalComments;
            totalFollowers = fb.totalFollowers;
            followerIncrease = fb.followerIncrease;
            averageLikes = fb.averageLikes;
            averageRetweets = fb.averageRetweets;
            averageComments = fb.averageComments;
        }
    }
}
