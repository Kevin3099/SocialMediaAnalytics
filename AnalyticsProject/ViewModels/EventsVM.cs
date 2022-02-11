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
        public Guid EventsId { get; set; }
        public string Hashtag { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public List<SummaryInformationVM> SummaryInformations { get; set; }

        public EventsVM() {
        }

        public EventsVM(Event events)
        {
            EventsId = events.EventId;
            Hashtag = events.Hashtag;
            DateFrom = events.DateFrom;
            DateTo = events.DateTo;
            SummaryInformations = new List<SummaryInformationVM>();

            if (events.SummaryInformations != null)
            {
              //  EventStats = (List<SummaryInformationVM>)events.EventStats;
            }
        }
        public EventsVM(List<SummaryInformationVM> eventsList, Event events)
        {
            EventsId = events.EventId;
            Hashtag = events.Hashtag;
            DateFrom = events.DateFrom;
            DateTo = events.DateTo;
            SummaryInformations = eventsList;
        }
    }
}
