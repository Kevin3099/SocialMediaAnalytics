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
        List<EventsVM> FilteredMyEvents(FilterVM filter, string? hashtag);
        ComparedStatsVM CompareEvents(List<EventsVM> eventList, string platform);
    }
    public class EventsService : ServiceBase, IEventsService
    {
        public EventsService(SMAContext ctx) : base(ctx)
        {
        }

        public ComparedStatsVM CompareEvents(List<EventsVM> myEventList, string platform)
        {
            var eventList = new List<EventsVM>();
            foreach (var myEvent in myEventList)
            {
                var hashtag = myEvent.Hashtag;
                var foundEvent = Ctx.Events.Where(x => x.Hashtag == hashtag).Select(x => new EventsVM(x)).FirstOrDefault();
                if(foundEvent != null) { 
                foundEvent.SummaryInformations = Ctx.SummaryInformations.Where(x => x.eventName == hashtag).Select(x => new SummaryInformationVM(x)).ToList();
                eventList.Add(foundEvent);
                }
                
            }
            
            int averageLikeIncrease = 0;
            int averageCommentIncrease = 0;
            int averageRetweetIncrease = 0;

            // List<string> mostCommonEffectiveWords = null;
            // DateTime bestPostTime = new DateTime();
            var mostCommonWords = new List<string>();
            var orderedList = eventList.OrderBy(x => x.DateTo.Date).ToList();
            foreach (var x in orderedList)
            {
                var info = new SummaryInformationVM();
                if (platform == "twitter")
                {
                    info = x.SummaryInformations.Where(x => x.Platform == "Twitter").FirstOrDefault();
                    mostCommonWords = CalculateMostCommonWords("Twitter");
                }
                else if (platform == "facebook")
                {
                    info = x.SummaryInformations.Where(x => x.Platform == "facebook").FirstOrDefault();
                    mostCommonWords = CalculateMostCommonWords("facebook");
                }
                else if (platform == "linkedIn")
                {
                    info = x.SummaryInformations.Where(x => x.Platform == "LinkedIn").FirstOrDefault();
                    mostCommonWords = CalculateMostCommonWords("LinkedIn");
                }
                //Change to increased numbers so get average off each event then minus it from previous then add increases and divide
                if (info != null) {
                averageLikeIncrease = averageLikeIncrease + info.averageLikes;
                averageRetweetIncrease = averageRetweetIncrease + info.averageRetweets;
                averageCommentIncrease = averageCommentIncrease + info.averageComments;
                } else
                {
                    averageLikeIncrease = 5;
                    averageRetweetIncrease = 5;
                    averageCommentIncrease = 5;
                }
            }

            averageCommentIncrease = averageCommentIncrease / orderedList.Count();
            averageLikeIncrease = averageLikeIncrease / orderedList.Count();
            averageRetweetIncrease = averageRetweetIncrease / orderedList.Count();

            
           // var bestPostTimes = CalculateBestPostTimes();

            var comparedEvents = new ComparedStatsVM()
            {
                averageFollowerIncrease = 20,
                Id = new Guid(),
                averageLikesIncrease = averageLikeIncrease,
                averageRetweetsIncrease = averageRetweetIncrease,
                averageCommentsIncrease = averageCommentIncrease,
                top5Posts = null
            };
            return comparedEvents;
        }

        public List<EventsVM> FilteredMyEvents(FilterVM filter, string? hashtag)
        {
            var myEventList = Ctx.Events
                .Where(x => x.DateTo == filter.DateTo && x.DateFrom == filter.DateFrom || x.Hashtag == hashtag)
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


        // DATES NOT PASSED DOWN PROPERLY
        public EventsVM SearchEvent(EventsVM newEvent)
        {
            var searchedEvent = Ctx.Events
                .Where(x => x.Hashtag == newEvent.Hashtag)
                .Include(x => x.SummaryInformations) // Include not adding Summary list
                .Select(x => new EventsVM(x)).FirstOrDefault(); // Fix at later point

            if (searchedEvent != null && searchedEvent.DateTo == newEvent.DateTo && searchedEvent.DateFrom == newEvent.DateFrom)
            {

                searchedEvent.SummaryInformations = Ctx.SummaryInformations
                  .Where(x => x.eventName == newEvent.Hashtag)
                  .Select(x => new SummaryInformationVM(x))
                  .ToList();
                return searchedEvent;
            }
            else {
                Twitter twitter = new Twitter(Constants.consumerKey, Constants.consumerKeySecret, Constants.access_token, Constants.access_token_secret);
                Facebook facebook = new Facebook();
                LinkedIn linkedIn = new LinkedIn();

                List<LinkedInDbVM> LiList = new List<LinkedInDbVM>();
                LiList = Ctx.LinkedInDbs

                    .Where(x => x.DatePosted.Date <= newEvent.DateTo.Date && x.DatePosted.Date >= newEvent.DateFrom.Date && x.content.Contains(newEvent.Hashtag))
                    .Select(x => new LinkedInDbVM(x)).ToList();

                List<FacebookDbVM> fbList = new List<FacebookDbVM>();
                fbList = Ctx.FacebookDbs
                    .Where(x => x.DatePosted.Date >= newEvent.DateTo.Date && x.DatePosted.Date <= newEvent.DateFrom.Date && x.content.Contains(newEvent.Hashtag))
                    .Select(x => new FacebookDbVM(x)).ToList();

                List<SummaryInformation> SumInfoList = new List<SummaryInformation>();
                SumInfoList.Add(facebook.GetSummaryInformationForEvents(newEvent, fbList));
                SumInfoList.Add(linkedIn.GetSummaryInformationForEvents(newEvent, LiList));
                SumInfoList.Add(twitter.GetSummaryInformationForEvent(newEvent.Hashtag));

                foreach (SummaryInformation x in SumInfoList)
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
        }

        private List<string> CalculateMostCommonWords(string platform) {
            // get event
            // if statement for each platform
            // if linkedIn
            // get all content string values 
            // https://stackoverflow.com/questions/62037874/find-the-5-most-common-words-in-a-string follow this

            // for twitter get tweet text list
            // do same thing
            return null;
        }
        private List<DateTime> CalculateBestPostTimes() {
            // figure out way to convert to 24 hour clock and ignore data .getHour??
            // loop over posts if above average - check time - add to count for that hour
            // highest counted hour, average posts in that hour 
            // that's best time to post
            throw new NotImplementedException();
        }
    }
}
