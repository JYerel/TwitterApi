using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TwitterApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace TwitterApi.Controllers.Twitter
{
    public class TwitterFeeds
    {
        public static HttpClient TwitterApiClient { get; set; } = new HttpClient();

        public static string TwitterName { get; set; } = "BBC"; // default


        public static List<TwitterFeedModel> GetTwitterFeeds(string inConsumerKey, string inConsumerSecret, string inTwitterUsername = "BBC")
        {
            TwitterApiClient = SetTokenBaseData();

            // Post token body content
            var content = new FormUrlEncodedContent(SetContentValues());
            var requestMessage = SetPostContent(content, Base64EncodedAuthenticationString(inConsumerKey, inConsumerSecret));

            // Make the request
            var response = TwitterApiClient.SendAsync(requestMessage).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // Get Tweets
            var accessToken = GrabTokenInString(responseBody);
            var twitterFeed = GetTweets(inTwitterUsername, accessToken);

            return twitterFeed;
        }

        private static List<TwitterFeedModel> GetTweets(string inTwitterUserName,string inToken)
        {
            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format(
                $"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={inTwitterUserName}&count=9"
                ));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + inToken);
            var responseUserTimeLine = TwitterApiClient.SendAsync(requestUserTimeline).Result;
            string responseTwitter = responseUserTimeLine.Content.ReadAsStringAsync().Result;

            // Fetch Json Result
            if (responseUserTimeLine.IsSuccessStatusCode)
            {
                var twitterFeeds = JsonConvert.DeserializeObject<List<TwitterFeedModel>>(responseTwitter);
                if (twitterFeeds?.Count > 0)
                {
                    TwitterName = twitterFeeds[0].user.name;
                }
                return twitterFeeds;
            }

            return null;
        }

        private static HttpClient SetTokenBaseData()
        {
            if (TwitterApiClient.BaseAddress == null)
            {
                Uri baseUri = new Uri("https://api.twitter.com");
                TwitterApiClient.BaseAddress = baseUri;
            }

            TwitterApiClient.DefaultRequestHeaders.Clear();
            TwitterApiClient.DefaultRequestHeaders.ConnectionClose = true;

            return TwitterApiClient;
        }


        private static string Base64EncodedAuthenticationString(string inConsumerKey, string inConsumerSecret)
        {
            string authenticationString = inConsumerKey + ":" + inConsumerSecret;
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));
        }

        private static List<KeyValuePair<string, string>> SetContentValues()
        {
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            return values;
        }

        private static HttpRequestMessage SetPostContent(FormUrlEncodedContent contents, string AuthenticationString)
        {
            var requestMessages = new HttpRequestMessage(HttpMethod.Post, "/oauth2/token");
            requestMessages.Headers.Authorization = new AuthenticationHeaderValue("Basic", AuthenticationString);
            requestMessages.Content = contents;
            return requestMessages;
        }

        private static string GrabTokenInString(string response)
        {
            return response.Substring(response.IndexOf("access_token\":\"") + "access_token\":\"".Length, response.IndexOf("\"}") - (response.IndexOf("access_token\":\"") + "access_token\":\"".Length));
        }
    }
}
