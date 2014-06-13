using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twix.Data.Models;

namespace Twix.Web.Models
{
    public class FollowerVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public List<Tweet> Tweets { get; set; }

    }
}