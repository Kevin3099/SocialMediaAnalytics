using System;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    public class Event
    {
        public Guid Id { get; set; }
        public string SearchedTerm { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public virtual TwitterSummary TwitterSummarys { get; set; }
        public virtual FacebookSummary FacebookSummarys { get; set; }
        public virtual LinkedInSummary LinkedInSummarys { get; set; }


    } 
}