using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;

namespace User_gems_challenge_interface_business
{
    public interface IUserBusiness
    {
        UserDto InsertUser(UserDto user);
        UserDto Login(UserDto user);
        void DeleteUserById(int id);
        int UpdateUser(UserDto user);
        UserDto GetUserByEmail(string email);
        UserDto GetUserById(int id);
        IEnumerable<UserDto> GetUsers(string name);
        IEnumerable<UserDto> GetAllUsers();
    }
}
