using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twix.Data.Models;

namespace Twix.Web.Models
{
    public class FollowerVM
    {
        public string UserName;
        public List<Tweet> Tweets { get; set; }

    }
}