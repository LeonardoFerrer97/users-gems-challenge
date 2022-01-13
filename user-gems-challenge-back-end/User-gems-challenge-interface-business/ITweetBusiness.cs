using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;

namespace User_gems_challenge_interface_business
{
    public interface ITweetBusiness
    {
        IEnumerable<TweetDto> GetTweets(int userId, bool isProfile);
        TweetDto Post(TweetDto tweet);
        TweetDto Put(TweetDto tweet);
        void Delete(int id);
    }
}
