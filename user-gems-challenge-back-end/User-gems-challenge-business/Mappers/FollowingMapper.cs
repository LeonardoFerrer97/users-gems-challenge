using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;
using User_gems_challenge_entity;

namespace User_gems_challenge_business.Mappers
{
    public class FollowingMapper
    {
        public FollowingDto EntityToDto(Following following)
        {
            if (following != null)
            {
                return new FollowingDto()
                {
                    Id = following.Id,
                    FollowingId = following.Following_Id,
                    UserId = following.User_Id
                };
            }
            return null;
        }
        public List<FollowingDto> ListEntityToListDto(IEnumerable<Following> followings)
        {
            List<FollowingDto> dtos = new List<FollowingDto>();
            foreach (var following in followings)
            {
                dtos.Add(EntityToDto(following));

            }
            return dtos;
        }

        public Following DtoToEntity(FollowingDto following)
        {
            if (following != null)
            {
                return new Following()
                {
                    Id = following.Id,
                    Following_Id = following.FollowingId,
                    User_Id = following.UserId
                };
            }
            return null;
        }

        public List<Following> ListDtoToListEntity(IEnumerable<FollowingDto> usuarios)
        {
            List<Following> dtos = new List<Following>();
            foreach (var Usuario in usuarios)
            {
                dtos.Add(DtoToEntity(Usuario));

            }
            return dtos;
        }
    }
}
