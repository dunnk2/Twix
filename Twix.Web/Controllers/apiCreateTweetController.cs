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
    public class apiCreateTweetController : ApiController
    {
        private ITweet _adapter;

        public apiCreateTweetController()
        {
            _adapter = new TweetAdapter();
        }

        public IHttpActionResult Post(Tweet tweet)
        {
            _adapter.CreateTweet(tweet);
            return Ok();
        }

    }
}
