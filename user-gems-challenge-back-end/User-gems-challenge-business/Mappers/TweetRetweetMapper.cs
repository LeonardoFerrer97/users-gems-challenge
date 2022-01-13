using System;
using System.Collections.Generic;
using User_gems_challenge_dto;
using User_gems_challenge_entity;

namespace User_gems_challenge_business.Mappers
{
    public class TweetRetweetMapper
    {
        public TweetDto EntityToDto(TweetRetweet tweet)
        {
            if (tweet != null)
            {
                return new TweetDto()
                {
                    Id = tweet.Id,
                    Description = tweet.Description,
                    CreatedAt = tweet.Created_At,
                    Image = tweet.Image,
                    UserId = tweet.User_Id,
                    RetweetUserId = tweet.RetweetUserId,
                    RetweetUserName = tweet.RetweetUserName,
                    UserName = tweet.User_Name,
                };
            }
            return null;
        }
        public List<TweetDto> ListEntityToListDto(IEnumerable<TweetRetweet> tweets)
        {
            List<TweetDto> dtos = new List<TweetDto>();
            foreach (var tweet in tweets)
            {
                dtos.Add(EntityToDto(tweet));

            }
            return dtos;
        }

        public TweetRetweet DtoToEntity(TweetDto tweet)
        {
            if (tweet != null)
            {
                return new TweetRetweet()
                {
                    Id = tweet.Id,
                    Description = tweet.Description,
                    Created_At = tweet.CreatedAt,
                    Image = tweet.Image,
                    User_Id = tweet.UserId,
                    RetweetUserId = tweet.RetweetUserId,
                    RetweetUserName = tweet.RetweetUserName,
                    User_Name = tweet.UserName,
                };
            }
            return null;
        }

        public List<TweetRetweet> ListDtoToListEntity(IEnumerable<TweetDto> tweets)
        {
            List<TweetRetweet> dtos = new List<TweetRetweet>();
            foreach (var tweet in tweets)
            {
                dtos.Add(DtoToEntity(tweet));

            }
            return dtos;
        }
    }
}
