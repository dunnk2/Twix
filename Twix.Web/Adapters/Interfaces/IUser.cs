using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twix.Data.Models;
using Twix.Web.Models;

namespace Twix.Web.Adapters.Interfaces
{
    interface IUser
    {
        void Create(User user);
        User GetUser(string username, string password);
        List<Tweet> GetTweets(User user);
        void Delete(int id);
        UserLoggedInVM FindUser(LoginAttempVM attempt);
        List<UserLoggedInVM> GetUserList();
        void CreateFollower(Follower follower);
    }
}
