using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_gems_challenge_dto
{
    public class FollowingDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int FollowingId { get; set; }
    }
}
