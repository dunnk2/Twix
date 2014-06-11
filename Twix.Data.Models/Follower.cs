using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twix.Data.Models
{
    public class Follower
    {
        public int Id { get; set; }
        [Required]
        public int User1Id { get; set; }
        [ForeignKey("User1Id")]
        public User User1 { get; set; }
        [Required]
        public int FollowerId { get; set; }
        [ForeignKey("FollowerId")]
        public User theFollower { get; set; }
    }
}
