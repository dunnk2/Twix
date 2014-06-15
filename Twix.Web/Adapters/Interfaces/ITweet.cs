using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twix.Data.Models;

namespace Twix.Web.Adapters.Interfaces
{
    interface ITweet
    {
        void CreateTweet(Tweet tweet);
        void Delete(int id);
        void Update(Tweet tweet);
        List<Tweet> GetTweets(int id);
    }
}
