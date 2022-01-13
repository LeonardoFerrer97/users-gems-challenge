using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;
using User_gems_challenge_entity;

namespace User_gems_challenge_business.Mappers
{
    public class RetweetMapper
    {
        public RetweetDto EntityToDto(Retweets retweet)
        {
            if (retweet != null)
            {
                return new RetweetDto()
                {
                    Id = retweet.Id,
                    TweetId = retweet.Tweet_Id,
                    UserId = retweet.User_Id,
                    CreatedAt = retweet.Created_At
                };
            }
            return null;
        }
        public List<RetweetDto> ListEntityToListDto(IEnumerable<Retweets> retweets)
        {
            List<RetweetDto> dtos = new List<RetweetDto>();
            foreach (var retweet in retweets)
            {
                dtos.Add(EntityToDto(retweet));

            }
            return dtos;
        }

        public Retweets DtoToEntity(RetweetDto retweet)
        {
            if (retweet != null)
            {
                return new Retweets()
                {
                    Id = retweet.Id,
                    Tweet_Id = retweet.TweetId,
                    User_Id = retweet.UserId,
                    Created_At = retweet.CreatedAt
                };
            }
            return null;
        }

        public List<Retweets> ListDtoToListEntity(IEnumerable<RetweetDto> retweets)
        {
            List<Retweets> dtos = new List<Retweets>();
            foreach (var retweet in retweets)
            {
                dtos.Add(DtoToEntity(retweet));

            }
            return dtos;
        }
    }
}
