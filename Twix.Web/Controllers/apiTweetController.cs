using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twix.Data.Models;
using Twix.Web.Adapters.Adapters;
using Twix.Web.Adapters.Interfaces;

namespace Twix.Web.Controllers
{
    public class apiTweetController : ApiController
    {
        private ITweet _adapter;

        public apiTweetController()
        {
            _adapter = new TweetAdapter();
        }

        public IHttpActionResult Get(int id)
        {
            List<Tweet> tweets = _adapter.GetTweets(id);
            return Ok(tweets);
        }

        public IHttpActionResult Post(Tweet tweet)
        {
            _adapter.CreateTweet(tweet);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            _adapter.Delete(id);
            return Ok();
        }
    }
}
