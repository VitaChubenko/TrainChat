using System.Collections.Generic;
using System.Linq;
using TrainChat.Model.DTO;
using TrainChat.Web.Api.Models;

namespace TrainChat.Web.Api.Infrastructure
{
    public static class MapHelper
    {
        public static UserViewModel ToUserViewModel(this UserDto user)
        {
            return new UserViewModel()
            {
                Login = user.Login, 
                Name = user.Name, 
                Password = user.Password, 
                Role = user.Role, 
                Id = user.Id
            };
        }

        public static List<UserViewModel> ToUserViewModelList(this IEnumerable<UserDto> users)
        {
            return
                users.Select(u => new UserViewModel()
                {
                    Login = u.Login, 
                    Name = u.Name, 
                    Password = u.Password, 
                    Role = u.Role, 
                    Id = u.Id
                }).ToList();
        }

        public static List<UserIndexViewModel> ToUserIndexViewModelList(this IEnumerable<UserDto> users)
        {
            return
                users.Select(u => new UserIndexViewModel()
                {
                    Login = u.Login, 
                    Name = u.Name, 
                    Id = u.Id,
                    Role = u.Role
                }).ToList();
        }

        public static UserDto ToUserDto(this UserViewModel user)
        {
            return new UserDto()
            {
                Login = user.Login, 
                Name = user.Name, 
                Password = user.Password, 
                Role = user.Role, 
                Id = user.Id
            };
        }

        public static List<UserDto> ToUserDtoList(this IEnumerable<UserViewModel> users)
        {
            return
                users.Select(u => new UserDto()
                {
                    Login = u.Login, 
                    Name = u.Name, 
                    Password = u.Password, 
                    Role = u.Role, 
                    Id = u.Id
                }).ToList();
        }
    }
}