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

        public ComparedStatsVM CompareEvents(List<EventsVM> eventList, string platform)
        {
            int averageLikeIncrease = 0;
            int averageCommentIncrease = 0;
            int averageRetweetIncrease = 0;

           // List<string> mostCommonEffectiveWords = null;
           // DateTime bestPostTime = new DateTime();

            var orderedList = eventList.OrderBy(x => x.DateTo);
            foreach(var x in orderedList)
            {
                var info = new SummaryInformationVM();
                if (platform == "Twitter")
                {
                    info = x.SummaryInformations.Where(x => x.Platform == "Twitter").FirstOrDefault();
                }
                else if (platform == "Facebook")
                {
                    info = x.SummaryInformations.Where(x => x.Platform == "Facebook").FirstOrDefault();
                }
                else
                {
                    info = x.SummaryInformations.Where(x => x.Platform == "LinkedIn").FirstOrDefault();
                }
                averageLikeIncrease = averageLikeIncrease + info.averageLikes;
                averageRetweetIncrease = averageRetweetIncrease + info.averageRetweets;
                averageCommentIncrease = averageCommentIncrease + info.averageComments;
            }

            averageCommentIncrease = averageCommentIncrease / orderedList.Count();
            averageLikeIncrease = averageLikeIncrease / orderedList.Count();
            averageRetweetIncrease = averageRetweetIncrease / orderedList.Count();

            var mostCommentWords = CalculateMostCommonWords();
            var bestPostTimes = CalculateBestPostTimes();

            var comparedEvents = new ComparedStatsVM()
            {
                Id = new Guid(),
                averageFollowerIncrease = 0,
                averageLikesIncrease = 0,
                averageRetweetsIncrease = 0,
                averageCommentsIncrease = 0,
                bestPostTime = bestPostTimes,
                mostCommonEffectiveWords = mostCommentWords,
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

        private List<string> CalculateMostCommonWords() {
            return null;
        }
        private List<DateTime> CalculateBestPostTimes() {
            throw new NotImplementedException();
        }
    }
}
