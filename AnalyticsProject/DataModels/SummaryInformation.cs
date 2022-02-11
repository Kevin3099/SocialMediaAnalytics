using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    public class SummaryInformation
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
        public string eventName { get; set; }
        public Guid? EventsId { get; set; }
    } 
}