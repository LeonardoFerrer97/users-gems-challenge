using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;

namespace User_gems_challenge_interface_business
{
    public interface IFollowingBusiness
    {
        FollowingDto CreateNewFollowing(FollowingDto Following);
        FollowingDto UpdateFollowing(FollowingDto Following);
        void Delete(int id);
    }
}
