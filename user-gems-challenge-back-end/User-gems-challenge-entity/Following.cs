using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_gems_challenge_entity
{
    public class Following
    {
        public int? Id { get; set; }
        public int User_Id { get; set; }
        public int Following_Id { get; set; }
    }
}
