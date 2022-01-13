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
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            return _userBusiness.GetUserById(id);
        }

        [HttpGet("email/{email}")]
        public ActionResult<UserDto> GetByEmail(string email)
        {
            return _userBusiness.GetUserByEmail(email);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<UserDto>> GetByName(string name)
        {
            return Ok(_userBusiness.GetUsers(name));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            return Ok(_userBusiness.GetAllUsers());
        }

        [HttpPost]
        public ActionResult<UserDto> Post([FromBody] UserDto usuario)
        {
            return _userBusiness.InsertUser(usuario);
        }

        [HttpPost("login")]
        public ActionResult<UserDto> Login([FromBody] UserDto usuario)
        {
            return _userBusiness.Login(usuario);
        }

        [HttpPut]
        public ActionResult<int> Put([FromBody] UserDto Usuario)
        {
            return _userBusiness.UpdateUser(Usuario);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userBusiness.DeleteUserById(id);
        }
    }
}
