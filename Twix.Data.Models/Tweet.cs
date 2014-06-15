using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twix.Data.Models

{
    //Tweets should contain: Authorname, favorites, retweets
    public class Tweet
    {
        public int Id { get; set; }
        public string message { get; set; }
        public int AuthorId { get; set; }
        public DateTime Created { get; set; }
        public string AuthorName { get; set; }
        public int likes { get; set; }
        public int retweets { get; set; }

    }
}
