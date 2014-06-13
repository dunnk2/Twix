using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twix.Data.Models
{
    public class User
    {
        //id
        public int Id { get; set; }
        //name
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //password
        public string Password { get; set; }
        //list of tweets
        public List<Tweet> Tweets { get; set; }
       
        //list of followers
        //public List<User> Following { get; set; }

    }
}
