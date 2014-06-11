using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twix.Data;
using Twix.Data.Models;
using Twix.Web.Adapters.Interfaces;

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

        public void Delete(Data.Models.User user)
        {
            throw new NotImplementedException();
        }
    }
}