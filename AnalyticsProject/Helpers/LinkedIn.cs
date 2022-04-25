﻿using System;
using System.IO;
using System.Net;
using AnalyticsProject.Properties;
using Newtonsoft.Json.Linq;
using AnalyticsProject.DataModels;
using System.Collections.Generic;
using AnalyticsProject.ViewModels;

namespace AnalyticsProject.Helpers
{
    public class LinkedIn
    {
        //Authentication
        public const string OauthVersion = "1.0";
        public const string OauthSignatureMethod = "HMAC-SHA1";

        public LinkedIn
          ()
        {
        }

        // Doesn't get Stats back
        public String GetRecentPosts(String user)
        {
            return "Not Implemented Yet";
        }

        // Same as Facebook but for LinkedIn, Seperated to bring in linkedIn down the line.
        public SummaryInformation GetSummaryInformationForUser(string user, FilterVM filter, List<LinkedInDbVM> LiList)
        {
            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 0;
            int averageLikes = 0;
            int averageRetweets = 0;
            int averageComments = 0;

            foreach (LinkedInDbVM post in LiList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / LiList.Count;
                averageRetweets = totalRetweets / LiList.Count;
                averageComments = totalComments / LiList.Count;
            }
            var Summary = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "LinkedIn",
                DateFrom = filter.DateFrom.Date,
                DateTo = filter.DateTo.Date,
                CountOfPosts = LiList.Count,
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

        // Same as Facebook but for LinkedIn, Seperated to bring in linkedIn down the line.
        public SummaryInformation GetSummaryInformationForEvents(EventsVM newEvent, List<LinkedInDbVM> LiList)
        {
            var totalLikes = 0;
            var totalRetweets = 0;
            var totalComments = 0;
            var averageLikes = 0;
            var averageRetweets = 0;
            var averageComments = 0;

            foreach (LinkedInDbVM post in LiList)
            {
                totalLikes = post.likes + totalLikes;
                totalRetweets = totalRetweets + post.retweets;
                totalComments = totalComments + post.comments;
                averageLikes = totalLikes / LiList.Count;
                averageRetweets = totalRetweets / LiList.Count;
                averageComments = totalComments / LiList.Count;
            }
            var Summary = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "LinkedIn",
                DateFrom = newEvent.DateFrom,
                DateTo = newEvent.DateTo,
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

            return Summary;
        }
    }
}