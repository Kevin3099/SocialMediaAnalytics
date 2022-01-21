using AnalyticsProject.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.ViewModels
{
    public class EventsVM
    {
        [Required]
        public Guid Id { get; set; }
        public string SearchedTerm { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public virtual TwitterSummary TwitterSummarys { get; set; }
        public virtual FacebookSummary FacebookSummarys { get; set; }
        public virtual LinkedInSummary LinkedInSummarys { get; set; }

        public EventsVM() {
        }

        public EventsVM(Event events)
        {
            Id = events.Id;
            SearchedTerm = events.SearchedTerm;
            DateFrom = events.DateFrom;
            DateTo = events.DateTo;
            TwitterSummarys = events.TwitterSummarys;
            FacebookSummarys = events.FacebookSummarys;
            LinkedInSummarys = events.LinkedInSummarys;
        }
    }
}
