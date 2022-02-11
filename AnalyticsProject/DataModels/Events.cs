using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Hashtag { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public virtual IList<SummaryInformationVM> SummaryInformations { get; set; }

    } 
}