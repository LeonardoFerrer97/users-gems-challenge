using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_gems_challenge_dto
{
    public class TweetDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? RetweetUserId { get; set; }
        public string RetweetUserName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
