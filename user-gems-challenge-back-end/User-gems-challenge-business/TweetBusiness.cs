using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_business.Mappers;
using User_gems_challenge_dto;
using User_gems_challenge_entity;
using User_gems_challenge_interface_business;
using User_gems_challenge_interface_repository;

namespace User_gems_challenge_business
{
    public class TweetBusiness : ITweetBusiness
    {
        private readonly TweetMapper mapper = new TweetMapper();
        private readonly TweetRetweetMapper mapperRetweet = new TweetRetweetMapper();
        private readonly IRepository<Tweets> _tweetRepository;
        private readonly ITweetRepository _tweetCustomRepository;

        public TweetBusiness(IRepository<Tweets> tweetRepository, ITweetRepository tweetCustomRepository)
        {
            _tweetRepository = tweetRepository;
            _tweetCustomRepository = tweetCustomRepository;
        }
        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            _tweetRepository.Remove(new { id });
        }

        public IEnumerable<TweetDto> GetTweets(int userId, bool isProfile)
        {
            var tweets = _tweetCustomRepository.GetTweets(userId);
            if (isProfile)
            {
                tweets = tweets.Where(t => t.User_Id == userId);
            }
            return mapperRetweet.ListEntityToListDto(tweets).OrderByDescending(e => e.CreatedAt);
        }

        public TweetDto Post(TweetDto tweet)
        {
            if (tweet == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            _tweetRepository.Add(mapper.DtoToEntity(tweet));
            return tweet;
        }

        public TweetDto Put(TweetDto tweet)
        {
            if (tweet == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            _tweetRepository.InstertOrUpdate(mapper.DtoToEntity(tweet), new { id = tweet.Id });
            return tweet;
        }
    }
}
