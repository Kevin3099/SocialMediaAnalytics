using System;
using System.IO;
using System.Net;
using AnalyticsProject.Properties;
using Newtonsoft.Json.Linq;
using AnalyticsProject.DataModels;
using AnalyticsProject.ViewModels;
using System.Collections.Generic;

namespace AnalyticsProject.Helpers
{
    public class Facebook
    {
        public const string OauthVersion = "1.0";
        public const string OauthSignatureMethod = "HMAC-SHA1";

        public Facebook()
        {
        }


        // Doesn't get Stats back
        public String GetRecentPosts(string user)
        {
            return "Not Implemented Yet";
        }

        public SummaryInformation GetSummaryInformationForUser(string user, FilterVM filter, List<FacebookDbVM> fbList)
        {

            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;

            foreach (FacebookDbVM post in fbList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / fbList.Count;
                averageRetweets = totalRetweets / fbList.Count;
                averageComments = totalComments / fbList.Count;
            }
            var Summary = new SummaryInformation()
            {
                Platform = "Facebook",
                Id = new Guid(),
                DateFrom = filter.DateFrom,
                DateTo = filter.DateTo,
                CountOfPosts = fbList.Count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50,
                eventName = ""
            };
            return Summary;
        }

        public SummaryInformation GetSummaryInformationForEvents(EventsVM newEvent, List<FacebookDbVM> fbList)
        {
            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;

            foreach (FacebookDbVM post in fbList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / fbList.Count;
                averageRetweets = totalRetweets / fbList.Count;
                averageComments = totalComments / fbList.Count;
            }
            var Summary = new SummaryInformation()
            {
                Platform = "Facebook",
                Id = new Guid(),
                DateFrom = newEvent.DateFrom,
                DateTo = newEvent.DateTo,
                CountOfPosts = fbList.Count,
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
            return Summary;
        }
    }
}