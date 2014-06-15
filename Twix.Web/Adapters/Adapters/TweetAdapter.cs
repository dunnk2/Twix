using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twix.Data;
using Twix.Data.Models;
using Twix.Web.Adapters.Interfaces;
using Twix.Web.Models;

namespace Twix.Web.Adapters.Adapters
{
    public class TweetAdapter : ITweet
    {
        public void CreateTweet(Data.Models.Tweet tweet)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            tweet.Created = DateTime.Now;
            db.Tweets.Add(tweet);
            db.SaveChanges();
        }

        public void Update(Tweet tweet)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Tweet tweetToEdit = db.Tweets.Where(t => t.Id == tweet.Id).FirstOrDefault();
            tweetToEdit.likes = tweet.likes;
            tweetToEdit.retweets = tweet.retweets;
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
            UserLoggedInVM user = db.Users.Where(u => u.Id == Authorid).Select(u => new UserLoggedInVM
            {
                Id = u.Id,
                //FirstName = u.FirstName,
                //LastName = u.LastName,
                //UserName = u.UserName,
                Followers = db.Followers.Where(f => f.UserId == u.Id).Select(f => new FollowerVM
                {
                    Id = f.theFollowed.Id,
                    //UserName = f.theFollowed.UserName,
                    //FirstName = f.theFollowed.FirstName
                }).ToList()
            }).FirstOrDefault();

            user.Tweets = db.Tweets.Where(t => t.AuthorId == user.Id).ToList();
            foreach (FollowerVM follower in user.Followers)
            {
                follower.Tweets = db.Tweets.Where(t => t.AuthorId == follower.Id).ToList();
                user.Tweets.AddRange(follower.Tweets);
            }

            List<Tweet> tweets = user.Tweets;
            tweets.Sort((x, y) => DateTime.Compare(x.Created, y.Created));
            tweets.Reverse();
            return (tweets);
        }
    }
}