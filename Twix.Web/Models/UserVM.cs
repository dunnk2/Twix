using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twix.Data.Models;

namespace Twix.Web.Models
{
    public class UserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public List<FollowerVM> Followers { get; set; }
    }
}