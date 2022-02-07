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
        public string Hashtag { get; set; }
        public virtual FilterVM Filter { get; set; }
        public virtual List<SummaryInformationVM> EventStats { get; set; }

        public EventsVM() {
        }

        public EventsVM(Event events)
        {
            Id = events.Id;
            Hashtag = events.Hashtag;
            Filter = events.Filter;
            EventStats = events.EventStats;
        }
    }
}
