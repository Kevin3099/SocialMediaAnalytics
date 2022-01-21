using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class LinkedInSummaryVM
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
        public LinkedInSummaryVM()
        {
        }

        public LinkedInSummaryVM(LinkedInSummary li)
        {
            Id = li.Id;
            DateFrom = li.DateFrom;
            DateTo = li.DateTo;
            CountOfPosts = li.CountOfPosts;
            totalLikes = li.totalLikes;
            totalRetweets = li.totalRetweets;
            totalComments = li.totalComments;
            totalFollowers = li.totalFollowers;
            followerIncrease = li.followerIncrease;
            averageLikes = li.averageLikes;
            averageRetweets = li.averageRetweets;
            averageComments = li.averageComments;
        }
    }
}
