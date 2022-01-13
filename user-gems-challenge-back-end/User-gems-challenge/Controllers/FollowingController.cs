using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;
using User_gems_challenge_interface_business;

namespace User_gems_challenge.Controllers
{
    [Route("[controller]")]
    public class FollowingController
    {
        private readonly IFollowingBusiness _followingBusiness;
        public FollowingController(IFollowingBusiness followingBusiness)
        {
            _followingBusiness = followingBusiness;
        }

        [HttpPost]
        public ActionResult<FollowingDto> Post([FromBody] FollowingDto following)
        {
            return _followingBusiness.CreateNewFollowing(following);
        }

        [HttpPut]
        public ActionResult<FollowingDto> Put([FromBody] FollowingDto following)
        {
            return _followingBusiness.UpdateFollowing(following);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _followingBusiness.Delete(id);
        }
    }
}
