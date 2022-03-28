using System;
using System.IO;
using System.Net;
using AnalyticsProject.Properties;
using Newtonsoft.Json.Linq;
using AnalyticsProject.DataModels;
using System.Collections.Generic;

namespace AnalyticsProject.Helpers
{
    public class Twitter
    {
        public const string OauthVersion = "1.0";
        public const string OauthSignatureMethod = "HMAC-SHA1";

        public Twitter
          (string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerKeySecret = consumerKeySecret;
            this.AccessToken = accessToken;
            this.AccessTokenSecret = accessTokenSecret;
        }

        public string ConsumerKey { set; get; }
        public string ConsumerKeySecret { set; get; }
        public string AccessToken { set; get; }
        public string AccessTokenSecret { set; get; }


        public List<TwitterMLDb> GetTimeLineTweets(String user) {
            var url = $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={user}&exclude_replies=true&include_rts=false&count=100";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = Constants.twitterBearerToken;
            var result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(httpResponse.StatusCode);

            var timeLineTweets = JSONParserForMLTwitter(result,user);
            return timeLineTweets;
        }

        public List<TwitterMLDb> GetRelatedTweets(String user,string hashtag)
        {
            var url = $"https://api.twitter.com/1.1/search/tweets.json?q={hashtag}&exclude_replies=true&count=200&include_rts=false";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = Constants.twitterBearerToken;
            var result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(httpResponse.StatusCode);

            var tweets = JSONParserForMLTwitterHashtag(result,user,hashtag);
            return tweets;
        }


        public SummaryInformation GetSummaryInformationForUser(String user)
        {
            var url = $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={user}&exclude_replies=true&include_rts=false";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = Constants.twitterBearerToken;
            var result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }
            var hashtag = "";
            Console.WriteLine(httpResponse.StatusCode);
            var Summary = JSONParserForSummaryInformation(result,hashtag);
            return Summary;
        }

        public SummaryInformation GetSummaryInformationForEvent(String hashtag)
        {
            var url = $"https://api.twitter.com/1.1/search/tweets.json?q={hashtag}&result_type=popular";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["Authorization"] = Constants.twitterBearerToken;
            var result = "";

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine(httpResponse.StatusCode);
            return JSONParserForSummaryInformationForEvent(result,hashtag);
        }

        private SummaryInformation JSONParserForSummaryInformation(string result,string hashtag) {

            dynamic dataArray = JArray.Parse(result);
            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 100;
            int averageComments = 10;
            var test = dataArray[0];
            Console.WriteLine(dataArray[0]);
            foreach (var post in dataArray)
            {
                totalLikes = post.favorite_count + totalLikes;
                totalRetweets = post.retweet_count + totalRetweets;
                totalComments = 25;
            }

            //Need to convert type before doing any calculations on it
            int averageLikes =  dataArray.Count;
            averageLikes = totalLikes / averageLikes;

            int averageRetweets = dataArray.Count;
            averageRetweets = totalRetweets / averageRetweets;

            var Summary = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "Twitter",
                DateFrom = DateTime.Now.AddDays(-7).Date,
                DateTo = DateTime.Now.Date,
                CountOfPosts = dataArray.Count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50,
                eventName = hashtag
            };

            return Summary;
        }

        private SummaryInformation JSONParserForSummaryInformationForEvent(string result, string hashtag)
        {

            dynamic dataArray = JObject.Parse(result);
            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 100;
            int averageComments = 10;
            foreach (var post in dataArray.statuses)
            {
                totalLikes = post.favorite_count + totalLikes;
                totalRetweets = post.retweet_count + totalRetweets;
                totalComments = 25;
            }

            //Need to convert type before doing any calculations on it
            int averageLikes = dataArray.search_metadata.count;
            averageLikes = totalLikes / averageLikes;
            int averageRetweets = dataArray.search_metadata.count;
            averageRetweets = totalRetweets / averageRetweets;

            var Summary = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "Twitter",
                DateFrom = DateTime.Now.AddDays(-7).Date,
                DateTo = DateTime.Now.Date,
                CountOfPosts = dataArray.search_metadata.count,
                totalLikes = totalLikes,
                totalRetweets = totalRetweets,
                totalComments = totalComments,
                averageLikes = averageLikes,
                averageRetweets = averageRetweets,
                averageComments = averageComments,
                followerIncrease = 5,
                totalFollowers = 50,
                eventName = hashtag
            };

            return Summary;
        }

        private List<TwitterMLDb> JSONParserForMLTwitter(string result,string user)
        {
            List<TwitterMLDb> myData = new List<TwitterMLDb>();
            dynamic dataArray = JArray.Parse(result);
            Console.WriteLine(dataArray[0]);
            foreach (var post in dataArray)
            {
                var myPost = new TwitterMLDb()
                {
                    Id = new Guid(),
                    user = user,
                  //  postDate = post.created_at,
                    postContent = post.text,
                    postTime = post.created_at,
                    platform = "Twitter",
                    likes = post.favorite_count,
                    retweets = post.retweet_count
                };
                myData.Add(myPost);
            }
            return myData;
        }

        private List<TwitterMLDb> JSONParserForMLTwitterHashtag(string result, string user,string hashtag)
        {
            List<TwitterMLDb> myData = new List<TwitterMLDb>();
            dynamic dataArray = JObject.Parse(result);
   //         Console.WriteLine(dataArray[0]);
            foreach (var post in dataArray.statuses)
            {
                var myPost = new TwitterMLDb()
                {
                    Id = new Guid(),
                    user = user,
                    //  postDate = post.created_at,
                    postContent = post.text,
                    postTime = post.created_at,
                    platform = "Twitter",
                    likes = post.favorite_count,
                    retweets = post.retweet_count
                };
                myData.Add(myPost);
            }
            return myData;
        }
    }
}

//public String GetRecentTweetsFromUserWithoutStats(String user)
//{
//    var url = "https://api.twitter.com/2/tweets/search/recent?query=from:'" + user + "'";
//    var httpRequest = (HttpWebRequest)WebRequest.Create(url);

//    httpRequest.Accept = "application/json";
//    httpRequest.Headers["Authorization"] = Constants.twitterBearerToken;
//    var result = "";

//    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
//    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
//    {
//        result = streamReader.ReadToEnd();
//        Console.WriteLine(result);
//    }

//    Console.WriteLine(httpResponse.StatusCode);


//    return result;
//}

