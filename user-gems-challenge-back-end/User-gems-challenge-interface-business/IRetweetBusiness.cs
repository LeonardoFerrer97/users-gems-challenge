using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;

namespace User_gems_challenge_interface_business
{
    public interface IRetweetBusiness
    {
        RetweetDto CreateRetweet(RetweetDto retweet);
        RetweetDto UpdateRetweet(RetweetDto retweet);
        void Delete(int id);
    }
}
