using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterApi.Models;

namespace TwitterApi.Data.Helpers
{
    public class TwitterHelper
    {
        public static string GetMainTweetUrl(TwitterFeedModel inModel)
        {
            
            return Constant.TwitterBaseUrl + inModel.user.screen_name + "/status/" + inModel.id;
        }
    }
}
