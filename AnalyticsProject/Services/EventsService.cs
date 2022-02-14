using AnalyticsProject.DataModels;
using AnalyticsProject.Helpers;
using AnalyticsProject.Properties;
using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AnalyticsProject.Services
{
    public interface IEventsService
    {
        EventsVM SearchEvent(EventsVM newEvent);
        List<EventsVM> MyEvents();
        List<EventsVM> FilteredMyEvents(FilterVM filter);
        EventsVM CompareEvents();
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

        public List<EventsVM> FilteredMyEvents(FilterVM filter)
        {
            var myEventList = Ctx.Events
                .Where(x => x.DateTo == filter.DateTo && x.DateFrom == filter.DateFrom)
                .Include(x => x.SummaryInformations)
                .Select(x => new EventsVM(x)).ToList();
            
            //Temporary Fix bad practice
            foreach(EventsVM x in myEventList)
            {
                x.SummaryInformations = Ctx.SummaryInformations
                   .Where(y => y.eventName == x.Hashtag)
                   .Select(x => new SummaryInformationVM(x))
                   .ToList();
            }
            return myEventList;
        }

        public List<EventsVM> MyEvents()
        {
            var myEventList = Ctx.Events
                 .Include(x => x.SummaryInformations)
                 .Select(x => new EventsVM(x)).ToList();

            //Temporary Fix Bad Practice
            foreach (EventsVM x in myEventList)
            {
                x.SummaryInformations = Ctx.SummaryInformations
                   .Where(y => y.eventName == x.Hashtag)
                   .Select(x => new SummaryInformationVM(x))
                   .ToList();
            }
            return myEventList;
        }

        public EventsVM SearchEvent(EventsVM newEvent)
        {
            var searchedEvent = Ctx.Events
                .Where(x => x.Hashtag == newEvent.Hashtag)
                .Include(x => x.SummaryInformations) // Include not adding Summary list
                .Select(x => new EventsVM(x)).FirstOrDefault(); // Fix at later point

            if (searchedEvent == null )
            {

                Twitter twitter = new Twitter(Constants.consumerKey, Constants.consumerKeySecret, Constants.access_token, Constants.access_token_secret);
                Facebook facebook = new Facebook();
                LinkedIn linkedIn = new LinkedIn();

                List<LinkedInDbVM> LiList = new List<LinkedInDbVM>();
                LiList = Ctx.LinkedInDbs
                    .Where(x => x.DatePosted <= newEvent.DateTo && x.DatePosted >= newEvent.DateFrom && x.content.Contains(newEvent.Hashtag))
                    .Select(x => new LinkedInDbVM(x)).ToList();

                List<FacebookDbVM> fbList = new List<FacebookDbVM>();
                fbList = Ctx.FacebookDbs
                    .Where(x => x.DatePosted <= newEvent.DateTo && x.DatePosted >= newEvent.DateFrom && x.content.Contains(newEvent.Hashtag))
                    .Select(x => new FacebookDbVM(x)).ToList();

                List<SummaryInformation> SumInfoList = new List<SummaryInformation>();
                SumInfoList.Add(facebook.GetSummaryInformationForEvents(newEvent, fbList));
                SumInfoList.Add(linkedIn.GetSummaryInformationForEvents(newEvent, LiList));
                SumInfoList.Add(twitter.GetSummaryInformationForEvent(newEvent.Hashtag));

                foreach(SummaryInformation x in SumInfoList)
                {
                    Ctx.SummaryInformations.Add(x);
                }
                Ctx.SaveChanges();

                var SIList = Ctx.SummaryInformations
                   .Where(x => x.eventName == newEvent.Hashtag)
                   .Select(x => new SummaryInformationVM(x)).ToList();



                newEvent.SummaryInformations = SIList;
                newEvent.EventsId = new Guid();

                Event myEvent = new Event()
                {
                    EventId = newEvent.EventsId,
                    Hashtag = newEvent.Hashtag,
                    SummaryInformations = SumInfoList,
                    DateTo = newEvent.DateTo,
                    DateFrom = newEvent.DateFrom

                };
                Ctx.Events.Add(myEvent);
                Ctx.SaveChanges();
                return newEvent;
            }
            else
            {
                searchedEvent.SummaryInformations = Ctx.SummaryInformations
                   .Where(x => x.eventName == newEvent.Hashtag)
                   .Select(x => new SummaryInformationVM(x))
                   .ToList();
                return searchedEvent;
            }

        }
    }
}
