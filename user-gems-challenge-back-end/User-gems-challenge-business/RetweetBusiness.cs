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
    public class RetweetBusiness : IRetweetBusiness
    {
        private readonly RetweetMapper mapper = new RetweetMapper();
        private readonly IRepository<Retweets> _retweetRepository;

        public RetweetBusiness(IRepository<Retweets> retweetRepository)
        {
            _retweetRepository = retweetRepository;
        }
        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            _retweetRepository.Remove(new { id });
        }

        public RetweetDto CreateRetweet(RetweetDto retweet)
        {
            if (retweet == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            _retweetRepository.Add(mapper.DtoToEntity(retweet));
            return retweet;
        }

        public RetweetDto UpdateRetweet(RetweetDto retweet)
        {
            if (retweet == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            _retweetRepository.InstertOrUpdate(mapper.DtoToEntity(retweet), new { id = retweet.Id });
            return retweet;
        }
    }
}
