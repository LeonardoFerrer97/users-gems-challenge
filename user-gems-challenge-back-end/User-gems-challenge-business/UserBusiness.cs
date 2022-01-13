using System;
using System.Collections.Generic;
using System.Linq;
using User_gems_challenge_business.Mappers;
using User_gems_challenge_dto;
using User_gems_challenge_entity;
using User_gems_challenge_interface_business;
using User_gems_challenge_interface_repository;

namespace Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly UserMapper mapper = new UserMapper();
        private readonly IRepository<User> _userRepository;
        private readonly IUserRepository _userCustomRepository;
        public UserBusiness(IRepository<User> userRepository, IUserRepository userCustomRepository)
        {
            _userRepository = userRepository;
            _userCustomRepository = userCustomRepository;
        }
        public UserDto GetUserById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Invalid id");
            }
            object parameters = new { Id };
            var usuario = _userRepository.GetData(parameters);
            if (usuario.Count() == 0)
            {
                return null;
            }
            return mapper.EntityToDto(usuario.ToList()[0]);
        }
        
        public UserDto GetUserByEmail(string email)
        {
            if (email == "")
            {
                throw new Exception("Email cant be null");
            }
            object parameters = new { email };
            User usuario = _userRepository.GetData(parameters).FirstOrDefault();
            if(usuario == null)
            {
                return null;
            }
            return mapper.EntityToDto(usuario);
        }
        public int UpdateUser(UserDto user)
        {
            if (user == null)
            {
                throw new Exception("User cant be null");
            }
            return _userRepository.InstertOrUpdate(mapper.DtoToEntity(user), new { email = user.Email });
        }

        public void DeleteUserById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Invalid id");
            }
            _userRepository.Remove(new { Id });
        }

        public UserDto InsertUser(UserDto user)
        {
            if (user == null)
            {
                throw new Exception("User cant be null");
            } else if (user.Name.Contains("5"))
            {
                throw new Exception("We dont like 5, sorry");
            }
            _userRepository.Add(mapper.DtoToEntity(user));

            return user;
        }

        public UserDto Login(UserDto user)
        {
            if (user == null)
            {
                throw new Exception("Invalid parameters");
            }
            var email = user.Email;
            object parameters = new { email };
            User usuario = _userRepository.GetData(parameters).FirstOrDefault();
            var password = user.Password;
            if (usuario == null)
            {
                throw new Exception("User not found");
            } else if (usuario.Password != password)
            {
                throw new Exception("Invalid password");
            }
            return mapper.EntityToDto(usuario);
        }

        public IEnumerable<UserDto> GetUsers(string name)
        {
            var users = _userCustomRepository.GetUsers(name);
            if (users == null)
            {
                return null;
            }
            return mapper.ListEntityToListDto(users);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return GetUsers("");
        }
    }
}
