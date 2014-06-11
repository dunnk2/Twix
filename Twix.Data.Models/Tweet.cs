using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twix.Data.Models
{
    public class Tweet
    {
        public int Id { get; set; }
        public string message { get; set; }
        public int AuthorId { get; set; }
    }
}
