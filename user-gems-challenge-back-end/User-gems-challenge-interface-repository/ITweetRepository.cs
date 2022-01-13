using System;
using System.Collections.Generic;
using User_gems_challenge_entity;

namespace User_gems_challenge_interface_repository
{
    public interface ITweetRepository
    {
        public IEnumerable<TweetRetweet> GetTweets(int userId);
    }
}
