using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_gems_challenge_entity
{
    public class Tweets
    {
        public int? Id { get; set; }
        public int User_Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
