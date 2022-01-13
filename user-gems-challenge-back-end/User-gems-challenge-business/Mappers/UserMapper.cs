using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_gems_challenge_dto;
using User_gems_challenge_entity;

namespace User_gems_challenge_business.Mappers
{
    public class UserMapper
    {
        public UserDto EntityToDto(User user)
        {
            if (user != null)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    IsAdmin = user.Is_Admin,
                    Name = user.Name
                };
            }
            return null;
        }
        public List<UserDto> ListEntityToListDto(IEnumerable<User> usuarios)
        {
            List<UserDto> dtos = new List<UserDto>();
            foreach (var usuario in usuarios)
            {
                dtos.Add(EntityToDto(usuario));

            }
            return dtos;
        }

        public User DtoToEntity(UserDto usuario)
        {
            if (usuario != null)
            {
                return new User()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Is_Admin = usuario.IsAdmin,
                    Name = usuario.Name,
                    Password = usuario.Password
                };
            }
            return null;
        }

        public List<User> ListDtoToListEntity(IEnumerable<UserDto> usuarios)
        {
            List<User> dtos = new List<User>();
            foreach (var Usuario in usuarios)
            {
                dtos.Add(DtoToEntity(Usuario));

            }
            return dtos;
        }
    }
}
