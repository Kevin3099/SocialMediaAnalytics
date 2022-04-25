using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnalyticsProject.DataModels
{
    //Describing the data model stored in the database for an Event
    public class Event
    {
        // Primary Key
        public Guid EventId { get; set; }
        public string Hashtag { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public virtual IList<SummaryInformation> SummaryInformations { get; set; }

    } 
}