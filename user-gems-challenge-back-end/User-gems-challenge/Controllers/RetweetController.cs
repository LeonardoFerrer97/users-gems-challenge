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
    public class RetweetController : ControllerBase
    {
        private readonly IRetweetBusiness _retweetBusiness;
        public RetweetController(IRetweetBusiness retweetBusiness)
        {
            _retweetBusiness = retweetBusiness;
        }

        [HttpPost]
        public ActionResult<RetweetDto> Post([FromBody] RetweetDto retweet)
        {
            return _retweetBusiness.CreateRetweet(retweet);
        }

        [HttpPut]
        public ActionResult<RetweetDto> Put([FromBody] RetweetDto retweet)
        {
            return _retweetBusiness.UpdateRetweet(retweet);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _retweetBusiness.Delete(id);
        }
    }
}
