using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
 /*  public class SummaryInformationVM
    {
        [Required]
        public virtual TwitterSummary TwitterSummarys { get; set; }
        public virtual FacebookSummary FacebookSummarys { get; set; }
        public virtual LinkedInSummary LinkedInSummarys { get; set; }

        public SummaryInformationVM() {
        }

        public SummaryInformationVM(TwitterSummary twitter,FacebookSummary facebook, LinkedInSummary linkedIn)
        {
            TwitterSummarys = twitter;
            FacebookSummarys = facebook;
            LinkedInSummarys = linkedIn;
        }
    }*/

    public class SummaryInformationVM
    {
        public string Platform { get; set; }
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
    

    public SummaryInformationVM()
    {
    }

    public SummaryInformationVM(SummaryInformation SI)
    {
        Platform = SI.Platform;
        Id = SI.Id;
        DateFrom = SI.DateFrom;
        DateTo = SI.DateTo;
        CountOfPosts = SI.CountOfPosts;
        totalLikes = SI.totalLikes;
        totalRetweets = SI.totalRetweets;
        totalComments = SI.totalComments;
        totalFollowers = SI.totalFollowers;
        followerIncrease = SI.followerIncrease;
        averageLikes = SI.averageLikes;
        averageRetweets = SI.averageRetweets;
        averageComments = SI.averageComments;
    }
    }
}
