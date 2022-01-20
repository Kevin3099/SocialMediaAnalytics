using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsProject.Controllers
{

	//https://www.karpach.com/twitter-application-only-authentication.htm reference
	public class TwitterController : Controller
	{
		public const string twitterBearerToken = "AAAAAAAAAAAAAAAAAAAAAEXVWwEAAAAAbGAyeHahb95YzxuwWi%2FzKjFo5ig%3DZxcC16Sq93nS0mQWhyFofxoVOXQmbi7dtzJEDFv8Nz9QJBpD80";
		public const string APIConsumerKey = "EoriVd9J6hAORPVRUSTvlhOMZ";
		public const string APIConsumerKeySecret = "JR0ln5wcSFf9kStCMomrXl7a1gZ5OCheIM3VqTSb3HRKmiT4if";
		public const string access_token = "1122978455744860165-IW7goTDg5GtM2BhtRgehLXJj0ZfIJf";
		public const string access_token_secret = "v8kYMveSmxJemdARyEgPj27UOqIphJYMhZ81i1KmWOf0D";
		public async Task<string> GetAccessToken()
		{
			var httpClient = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
			var customerInfo = Convert.ToBase64String(new UTF8Encoding()
									  .GetBytes(APIConsumerKey + ":" + APIConsumerKeySecret));
			request.Headers.Add("Authorization", "Basic " + customerInfo);
			request.Content = new StringContent("grant_type=client_credentials",
													Encoding.UTF8, "application/x-www-form-urlencoded");

			HttpResponseMessage response = await httpClient.SendAsync(request);

			string json = await response.Content.ReadAsStringAsync();
			var serializer = new JavaScriptSerializer();
			dynamic item = serializer.Deserialize<object>(json);
			return item["access_token"];
		}

		public async Task<IEnumerable<string>> GetTweets(string userName, int count, string accessToken = null)
		{
			if (accessToken == null)
			{
				accessToken = await GetAccessToken();
			}

			var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get,
				string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count ={ 0 } & screen_name ={ 1}&trim_user = 1 & exclude_replies = 1", count, userName));
			requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
			var httpClient = new HttpClient();
			HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
			var serializer = new JavaScriptSerializer();
			dynamic json = serializer.Deserialize<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
			var enumerableTweets = (json as IEnumerable<dynamic>);

			if (enumerableTweets == null)
			{
				return null;
			}
			return enumerableTweets.Select(t => (string)(t["text"].ToString()));
		}


		// reference 2 https://coderbuddy.wordpress.com/2010/08/28/oauth-twitter-search-in-c/
	//	public async void test() {
	//		oAuthTwitter oauth = new oAuthTwitter();
	//		oauth.ConsumerKey = "Your-twitter-oauth-consumerkey";
	//		oauth.ConsumerSecret = "Your-twitter-oauth-consumersecret";
	//		System.Diagnostics.Process.Start(oauth.AuthorizationLinkGet());
	//		oauth.AccessTokenGet(oauth.OAuthToken, twitterpin);
	//		string result = oauth.oAuthWebRequest(oAuthTwitter.Method.GET, "http://search.twitter.com/search.json", "q=" + search_keyword + "&rpp=100&lang=en");
					
			//The following code is a straight copy from jamiedigi.com
	//				HashTable jsonHash = (Hashtable)JSON.JsonDecode(jsonCode);
	//				ArrayList jsonResults = (ArrayList)jsonHash["results"];
	//					foreach (object objResult in jsonResults)
	//					{
	//						Hashtable jsonResult = (Hashtable)objResult;
	//						System.Diagnostics.Debug.WriteLine("User ID: "
	//				+ jsonResult["from_user_id"].ToString());
	//						System.Diagnostics.Debug.WriteLine("Tweet text: "
	//						+ jsonResult["text"].ToString());
	//						System.Diagnostics.Debug.WriteLine("Tweet date: "
	//						+ jsonResult["created_at"].ToString());
	//						System.Diagnostics.Debug.WriteLine("User name: "
	//						+ jsonResult["from_user"].ToString());
	//						System.Diagnostics.Debug.WriteLine("Language: "
	//						+ jsonResult["iso_language_code"].ToString());
	//		}
}
}


/*
https://stackoverflow.com/questions/61244505/how-to-make-an-oauth-1-twitter-api-call-with-c-sharp-dotnet-core-3-1 best method


Get 5 most recent tweets
endpoint: 


Get search term tweets
https://api.twitter.com/1.1/users/search.json?q=soccer

Get tweets between dates and times
https://api.twitter.com/2/tweets/search/all?start_time=2022-01-01T00:00:00.000Z&end_time=2022-01-03T00:00:00.000Z

Above with max 100 tweets returned 
https://api.twitter.com/2/tweets/search/all?start_time=2022-01-01T00:00:00.000Z&end_time=2022-01-03T00:00:00.000Z&max_results=100

Get tweets containing  text between dates
 
 */