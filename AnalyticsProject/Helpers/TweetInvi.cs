using AnalyticsProject.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;

namespace AnalyticsProject.Helpers
{
  //  public const string twitterBearerToken = "AAAAAAAAAAAAAAAAAAAAAEXVWwEAAAAAbGAyeHahb95YzxuwWi%2FzKjFo5ig%3DZxcC16Sq93nS0mQWhyFofxoVOXQmbi7dtzJEDFv8Nz9QJBpD80";
    public class TweetInvi
    {
        static async Task start(string[] args)
        {
            var userClient = new TwitterClient(Constants.APIKey, Constants.APIKeySecret, Constants.access_token, Constants.access_token_secret);
            var user = await userClient.Users.GetAuthenticatedUserAsync();
            Console.WriteLine(user);
            var tweet = await userClient.Tweets.PublishTweetAsync("Hello tweetinvi world!");
            Console.WriteLine("You published the tweet : " + tweet);

        }

    }
}
