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
        // Authentication Methods
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

        // Creates the Summary Information object for the user
        public SummaryInformation GetSummaryInformationForUser(string user, FilterVM filter, List<FacebookDbVM> fbList)
        {

            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;
            
            //Looping through list of posts passed in and calculating stats based off that list.
            foreach (FacebookDbVM post in fbList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / fbList.Count;
                averageRetweets = totalRetweets / fbList.Count;
                averageComments = totalComments / fbList.Count;
            }
            //Building the summary object to pass back
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

        // Similar to above but for events, need a few extra parameters.
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
            // Creating the summary object like above but adding in Event Hashtag
            // will change in future development to use actual facebook api
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