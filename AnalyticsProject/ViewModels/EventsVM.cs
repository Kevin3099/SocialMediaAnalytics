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
        public string DateFromDisplay { get { return DateFrom.ToString("dd MMM yyyy"); } set { } }
        public string DateToDisplay { get { return DateTo.ToString("dd MMM yyyy"); } set { } }
        public List<SummaryInformationVM> SummaryInformations { get; set; }

        public EventsVM() {
        }

        public EventsVM(Event events)
        {
            EventsId = events.EventId;
            Hashtag = events.Hashtag;
            DateFrom = events.DateFrom;
            DateTo = events.DateTo;
            DateFromDisplay = this.DateFromDisplay;
            DateFromDisplay = this.DateToDisplay;
            SummaryInformations = new List<SummaryInformationVM>();

            if (events.SummaryInformations != null)
            {
                foreach (var i in events.SummaryInformations)
                {
                    var summaryInfo = new SummaryInformationVM(i);
                    SummaryInformations.Add(summaryInfo);
                }
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
