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
        List<EventsVM> FilteredMyEvents();
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

        public List<EventsVM> FilteredMyEvents()
        {
            throw new NotImplementedException();
        }

        public List<EventsVM> MyEvents()
        {
            throw new NotImplementedException();
        }

        public EventsVM SearchEvent(EventsVM newEvent)
        {
            var searchedEvent = Ctx.Events.Include(x => x.SummaryInformations)
                .Where(x => x.Hashtag == newEvent.Hashtag)
                .Select(x => new EventsVM(x)).FirstOrDefault();

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


                Ctx.SummaryInformations.Add(facebook.GetSummaryInformationForEvents(newEvent, fbList));
                Ctx.SummaryInformations.Add(linkedIn.GetSummaryInformationForEvents(newEvent, LiList));
                Ctx.SummaryInformations.Add(twitter.GetSummaryInformationForEvent(newEvent.Hashtag));
                Ctx.SaveChanges();

                //create summary info list instead of adding them all to database individually, create list and then for each in list add to 
                //database then use the same list to be the summary information list in event, add all to database and save changes and upload

                var SIList = Ctx.SummaryInformations
                   .Where(x => x.eventName == newEvent.Hashtag)
                   .Select(x => new SummaryInformationVM(x)).ToList();



                newEvent.SummaryInformations = SIList;
                newEvent.EventsId = new Guid();

                Event myEvent = new Event()
                {
                    EventId = newEvent.EventsId,
                    Hashtag = newEvent.Hashtag,
                    SummaryInformations = newEvent.SummaryInformations,
                    DateTo = newEvent.DateTo,
                    DateFrom = newEvent.DateFrom

                };
                Ctx.Events.Add(myEvent);
                Ctx.SaveChanges();
                return newEvent;
            }
            else
            {
                return searchedEvent;
            }

        }
    }
}
