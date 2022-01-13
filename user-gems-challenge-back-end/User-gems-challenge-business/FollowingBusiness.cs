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
    public class FollowingBusiness : IFollowingBusiness
    {
        private readonly FollowingMapper mapper = new FollowingMapper();
        private readonly IRepository<Following> _followingRepository;

        public FollowingBusiness(IRepository<Following> followingRepository)
        {
            _followingRepository = followingRepository;
        }
        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            _followingRepository.Remove(new { id });
        }

        public FollowingDto CreateNewFollowing(FollowingDto following)
        {
            if (following == null)
            {
                throw new Exception("Missing parameters");
            }
            _followingRepository.Add(mapper.DtoToEntity(following));
            return following;
        }

        public FollowingDto UpdateFollowing(FollowingDto following)
        {
            if (following == null)
            {
                throw new Exception("Missing parameters");
            }
            _followingRepository.InstertOrUpdate(mapper.DtoToEntity(following), new { id = following.Id });
            return following;
        }
    }
}
