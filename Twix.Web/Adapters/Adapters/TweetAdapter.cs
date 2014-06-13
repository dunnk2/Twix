using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twix.Data;
using Twix.Data.Models;
using Twix.Web.Adapters.Interfaces;

namespace Twix.Web.Adapters.Adapters
{
    public class TweetAdapter : ITweet
    {
        public void CreateTweet(Data.Models.Tweet tweet)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Tweets.Add(tweet);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Tweet tweetToRemove = db.Tweets.Where(t => t.Id == id).FirstOrDefault();
            db.Tweets.Remove(tweetToRemove);
            db.SaveChanges();
        }

        public List<Tweet> GetTweets(int Authorid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Tweet> tweets = db.Tweets.Where(t => t.AuthorId == Authorid).ToList();
            return (tweets);
        }
    }
}