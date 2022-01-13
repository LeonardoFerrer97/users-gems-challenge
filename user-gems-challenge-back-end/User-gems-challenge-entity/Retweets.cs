using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_gems_challenge_entity
{
    public class Retweets
    {
        public int? Id { get; set; }
        public int User_Id { get; set; }
        public int Tweet_Id { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
