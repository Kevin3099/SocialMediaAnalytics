//using AnalyticsProject.Properties;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Tweetinvi;

//namespace AnalyticsProject.Helpers
//{
//    public class TweetInvi
//    {
//        public static async Task start()
//        {
//            // we create a client with your user's credentials
//            var userClient = new TwitterClient("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");

//            // request the user's information from Twitter API
//            var user = await userClient.Users.GetAuthenticatedUserAsync();
//            Console.WriteLine("Hello " + user);

//            // publish a tweet
//            var tweet = await userClient.Tweets.PublishTweetAsync("Hello tweetinvi world!");
//            Console.WriteLine("You published the tweet : " + tweet);

//            //  https://api.twitter.com/2/tweets/search/recent?query=from:ItColdHearted15
//        }
//        public static async test2() {
//            var twitter = new Twitter(MvcApplication.OauthConsumerKey,
//                              MvcApplication.OauthConsumerKeySecret,
//                              MvcApplication.OauthAccesToken,
//                              MvcApplication.OauthAccessTokenSecret);

//            //twitter.PostStatusUpdate(status, 54.35,-0.2);
//            var response = twitter.GetTweets("johnnewcombeuk", 5);

//            dynamic timeline = System.Web.Helpers.Json.Decode(response);

//            foreach (var tweet in timeline)
//            {
//                string text = timeLineMention["text"].ToString();
//                model.Timeline.Add(text);
//            }
//        }
//    }
//}

using System;
using System.IO;
using System.Net;
using AnalyticsProject.Properties;
using Newtonsoft.Json.Linq;
using AnalyticsProject.DataModels;

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


        // Doesn't get Stats back
        public String GetRecentTweets(String user)
        {
            var url = "https://api.twitter.com/2/tweets/search/recent?query=from:'" + user + "'";
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


            return result;
        }

        public SummaryInformation GetSummaryInformation(String user)
        {
            var url = "https://api.twitter.com/1.1/search/tweets.json?q='" + user + "'+&result_type=popular";
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
            SummaryInformation Summary = JSONParserForSummaryInformation(result,hashtag);
            return Summary;
        }

        public SummaryInformation GetEventTweetsFromUser(String hashtag)
        {
            var url = "https://api.twitter.com/1.1/search/tweets.json?q='" + hashtag + "'+&result_type=popular";
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
            //  Event myEvent = JSONParserForEvents(result);
            // return myEvent;
            return JSONParserForSummaryInformation(result,hashtag);
        }

        public SummaryInformation JSONParserForSummaryInformation(string result,string hashtag) {

            dynamic data = JObject.Parse(result);
            int totalLikes = 0;
            int totalRetweets = 0;
            int totalComments = 100;
            int averageComments = 10;

            foreach (var post in data.statuses)
            {
                totalLikes = post.favorite_count + totalLikes;
                totalRetweets = post.retweet_count + totalRetweets;
                totalComments = 25;
            }

            //Need to convert type before doing any calculations on it
            int averageLikes =  data.search_metadata.count;
            averageLikes = totalLikes / averageLikes;
            int averageRetweets = data.search_metadata.count;
            averageRetweets = totalRetweets / averageRetweets;

            var Summary = new SummaryInformation()
            {
                Id = new Guid(),
                Platform = "Twitter",
                DateFrom = DateTime.Now.AddDays(-7).Date,
                DateTo = DateTime.Now.Date,
                CountOfPosts = data.statuses.Count,
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

        public Event JSONParserForEvents(String result) {
            var customEvent = new Event();
            return customEvent;
        }
    }
}