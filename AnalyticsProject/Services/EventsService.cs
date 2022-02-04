using AnalyticsProject.DataModels;
using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsProject.Services
{
    public interface IEventsService
    {
        EventsVM CreateEvent();
        EventsVM CompareEvents();
        List<TwitterSummary> searchHashtagTwitter();
        List<LinkedInSummary> searchHashtagLinkedIn();
        List<FacebookSummary> searchHashtagFacebook();

        List<SummaryInformation> searchHashtagAll();
    }
    public class EventsService : ServiceBase, IEventsService
    {
        public EventsService(SMAContext ctx) : base(ctx)
        {
        }

        public EventsVM CompareEvents()
        {
            throw new NotImplementedException();
        }

        public EventsVM CreateEvent()
        {
            throw new NotImplementedException();
        }

        public List<SummaryInformation> searchHashtagAll()
        {
            throw new NotImplementedException();
        }

        public List<FacebookSummary> searchHashtagFacebook()
        {
            throw new NotImplementedException();
        }

        public List<LinkedInSummary> searchHashtagLinkedIn()
        {
            throw new NotImplementedException();
        }

        public List<TwitterSummary> searchHashtagTwitter()
        {
            throw new NotImplementedException();
        }
    }
}
