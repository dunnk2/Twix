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
    public class UserAdapter : IUser
    {
        public void Create(Data.Models.User user)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public Data.Models.User GetUser(string username, string password)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
            return user;
        }

        public List<Data.Models.Tweet> GetTweets(Data.Models.User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Id == id).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();
        }


        public UserLoggedInVM FindUser(LoginAttempVM attempt)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            UserLoggedInVM user = db.Users.Where(u => u.UserName == attempt.UsernameAttempt && u.Password == attempt.PasswordAttempt).Select(u => new UserLoggedInVM {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Followers = db.Followers.Where(f => f.UserId == u.Id).Select(f => new FollowerVM 
                {
                    Id = f.theFollowed.Id,
                    UserName = f.theFollowed.UserName,
                    FirstName = f.theFollowed.FirstName

                }).ToList()
            }).FirstOrDefault();

            foreach (FollowerVM follower in user.Followers)
            {
                follower.Tweets = db.Tweets.Where(t => t.AuthorId == follower.Id).ToList();
            }

            return user;
        }




        public List<UserLoggedInVM> GetUserList()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<UserLoggedInVM> userList = db.Users.Select(u => new UserLoggedInVM
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserName = u.UserName,
                Followers = db.Followers.Where(f => f.UserId == u.Id).Select(f => new FollowerVM
                {
                    UserName = f.theFollowed.UserName
                }).ToList()
            }).ToList();
            return userList;
        }


        public void CreateFollower(Follower follower)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Followers.Add(follower);
            db.SaveChanges();
        }
    }
}

            //ApplicationDbContext db = new ApplicationDbContext();
            //UserLoggedInVM user = db.Users.Where(u => u.UserName == attempt.UsernameAttempt).Where(u => u.Password == attempt.PasswordAttempt).Select(
            //    u => new UserLoggedInVM
            //    {

            //    }).FirstOrDefault();
            //return user;