using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;
using User_gems_challenge_entity;

namespace User_gems_challenge_business.Mappers
{
    public class TweetMapper
    {
        public TweetDto EntityToDto(Tweets tweet)
        {
            if (tweet != null)
            {
                return new TweetDto()
                {
                    Id = tweet.Id,
                    Description = tweet.Description,
                    CreatedAt = tweet.Created_At,
                    Image = tweet.Image,
                    UserId = tweet.User_Id
                };
            }
            return null;
        }
        public List<TweetDto> ListEntityToListDto(IEnumerable<Tweets> tweets)
        {
            List<TweetDto> dtos = new List<TweetDto>();
            foreach (var tweet in tweets)
            {
                dtos.Add(EntityToDto(tweet));

            }
            return dtos;
        }

        public Tweets DtoToEntity(TweetDto tweet)
        {
            if (tweet != null)
            {
                return new Tweets()
                {
                    Id = tweet.Id,
                    Description = tweet.Description,
                    Created_At = tweet.CreatedAt,
                    Image = tweet.Image,
                    User_Id = tweet.UserId
                };
            }
            return null;
        }

        public List<Tweets> ListDtoToListEntity(IEnumerable<TweetDto> tweets)
        {
            List<Tweets> dtos = new List<Tweets>();
            foreach (var tweet in tweets)
            {
                dtos.Add(DtoToEntity(tweet));

            }
            return dtos;
        }
    }
}
