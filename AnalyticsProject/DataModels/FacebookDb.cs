using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    public class FacebookDb
    {
        public Guid Id { get; set; }
        public DateTimeOffset DatePosted { get; set; }
        public string content { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }
        public int comments { get; set; }
    } 
}