using AnalyticsProject.DataModels;
using AnalyticsProject.Helpers;
using AnalyticsProject.Properties;
using AnalyticsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var searchedEvent = Ctx.Events
                .Where(x => x.Hashtag == newEvent.Hashtag)
                .Select(x => new EventsVM(x)).FirstOrDefault(); //Need to add .Include to add in Stats and Filter




            if (searchedEvent == null) { 
            Twitter twitter = new Twitter(Constants.consumerKey, Constants.consumerKeySecret, Constants.access_token, Constants.access_token_secret);
            Ctx.SummaryInformations.Add(twitter.GetEventTweetsFromUser(newEvent.Hashtag));
            Ctx.SaveChanges();

            GetFilteredLiFbSummaryInfo(newEvent);

            var SIList = Ctx.SummaryInformations
               .Where(x => x.eventName == newEvent.Hashtag)
               .Select(x => new SummaryInformationVM(x)).ToList();

            newEvent.EventStats = SIList;
            newEvent.Id = new Guid();

                Event myEvent = new Event()
                {
                        Hashtag = newEvent.Hashtag,
                        EventStats = newEvent.EventStats,
                        Filter = newEvent.Filter   
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

        public void GetFilteredLiFbSummaryInfo(EventsVM newEvent)
        {

            List<LinkedInDbVM> LiList = new List<LinkedInDbVM>();
            LiList = Ctx.LinkedInDbs
                .Where(x => x.DatePosted <= newEvent.Filter.DateTo && x.DatePosted >= newEvent.Filter.DateFrom && x.content.Contains(newEvent.Hashtag))
                .Select(x => new LinkedInDbVM(x)).ToList();

            List<FacebookDbVM> fbDb = new List<FacebookDbVM>();
            fbDb = Ctx.FacebookDbs
                .Where(x => x.DatePosted <= newEvent.Filter.DateTo && x.DatePosted >= newEvent.Filter.DateFrom && x.content.Contains(newEvent.Hashtag))
                .Select(x => new FacebookDbVM(x)).ToList();

            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;

            foreach (FacebookDbVM post in fbDb)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / fbDb.Count;
                averageRetweets = totalRetweets / fbDb.Count;
                averageComments = totalComments / fbDb.Count;
            }
            var Summary = new SummaryInformation()
            {
                Platform = "Facebook",
                Id = new Guid(),
                DateFrom = newEvent.Filter.DateFrom,
                DateTo = newEvent.Filter.DateTo,
                CountOfPosts = fbDb.Count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50,
                eventName = newEvent.Hashtag
            };

            totalLikes = 0;
            totalRetweets = 0;
            totalComments = 0;
            averageLikes = 0;
            averageRetweets = 0;
            averageComments = 0;

            foreach (LinkedInDbVM post in LiList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / LiList.Count;
                averageRetweets = totalRetweets / LiList.Count;
                averageComments = totalComments / LiList.Count;
            }
            var Summary2 = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "LinkedIn",
                DateFrom = newEvent.Filter.DateFrom,
                DateTo = newEvent.Filter.DateTo,
                CountOfPosts = LiList.Count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50,
                eventName = newEvent.Hashtag
            };

            Ctx.SummaryInformations.Add(Summary);
            Ctx.SummaryInformations.Add(Summary2);
            Ctx.SaveChanges();
        }

    }
}
