using System;
using System.Collections.Generic;
using User_gems_challenge_entity;

namespace User_gems_challenge_interface_repository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUsers(string name);
    }
}
