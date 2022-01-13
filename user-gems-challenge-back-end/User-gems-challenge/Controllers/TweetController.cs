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
    public class TweetController : ControllerBase
    {
        private readonly ITweetBusiness _tweetBusiness;
        public TweetController(ITweetBusiness tweetBusiness)
        {
            _tweetBusiness = tweetBusiness;
        }

        [HttpGet("User/{userId}")]
        public ActionResult<IEnumerable<TweetDto>> GetTweets([FromRoute] int userId, bool? isProfile)
        {
            return Ok(_tweetBusiness.GetTweets(userId, isProfile ?? false));
        }

        [HttpPost]
        public ActionResult<TweetDto> Post([FromBody] TweetDto tweet)
        {
            return _tweetBusiness.Post(tweet);
        }

        [HttpPut]
        public ActionResult<TweetDto> Put([FromBody] TweetDto tweet)
        {
            return _tweetBusiness.Put(tweet);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tweetBusiness.Delete(id);
        }
    }
}
