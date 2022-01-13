using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_gems_challenge_dto
{
    public class RetweetDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int TweetId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
