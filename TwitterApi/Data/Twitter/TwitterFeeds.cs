using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TwitterApi.Models;

namespace TwitterApi.Controllers.Twitter
{
    public class TwitterFeeds
    {
        public static HttpClient TwitterApiClient { get; set; } = new HttpClient();

        public static List<TwitterFeedModel> GetTwitterFeeds()
        {
            TwitterApiClient = SetTokenBaseData();

            // Post token body content
            var content = new FormUrlEncodedContent(SetContentValues());
            var requestMessage = SetPostContent(content, base64EncodedAuthenticationString());

            // Make the request
            var response = TwitterApiClient.SendAsync(requestMessage).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            // Fetch Token
            var accessToken = GrabTokenInString(responseBody);

            // Get Tweets
            var twitterFeed = GetTweets(accessToken);

            return twitterFeed;
        }


        private static List<TwitterFeedModel> GetTweets(string token)
        {
            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format($"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=BBC&count=9"));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + token);
            var responseUserTimeLine = TwitterApiClient.SendAsync(requestUserTimeline).Result;
            string responseTwitter = responseUserTimeLine.Content.ReadAsStringAsync().Result;

            // Fetch Json Result
            var twitterFeeds = JsonConvert.DeserializeObject<List<TwitterFeedModel>>(responseTwitter);
            return twitterFeeds;
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

        private static string base64EncodedAuthenticationString()
        {
            string authenticationString = "DSnZt2yM4GHGxjZDe1oyrrf0Q:cnHL52gB4dSesiyejTONs01wajvPlNSdsjW6Yj0GDhNwxrtiY1";
            return Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
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
