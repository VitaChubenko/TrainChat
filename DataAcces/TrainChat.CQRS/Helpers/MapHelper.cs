using System.Collections.Generic;
using System.Linq;
using TrainChat.Model;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Helpers
{
    public static class MapHelper
    {
        public static UserDto ToUserDto(this UserEntity user)
        {
            return new UserDto()
            {
                Id = (user.Id + 2) * 3,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static IEnumerable<UserDto> ToUserDtoList(this IEnumerable<UserEntity> users)
        {
            return users.Select(u =>
                new UserDto()
                {
                    Id = (u.Id + 2) * 3,
                    Login = u.Login,
                    Name = u.Name,
                    Password = u.Password,
                    Role = u.Role
                });
        }

        public static UserEntity ToUserEntity(this UserDto user)
        {
            return new UserEntity()
            {
                Id = user.Id / 3 - 2,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static RoomDto ToRoomDto(this RoomEntity room)
        {
            return new RoomDto()
            {
                Id = (room.Id + 2) * 3,
                Name = room.Name,
                IsPrivate = room.IsPrivate
            };
        }

        public static IEnumerable<RoomDto> ToRoomDtoList(this IEnumerable<RoomEntity> rooms)
        {
            return rooms.Select(r => new RoomDto()
            {
                Id = (r.Id + 2) * 3,
                Name = r.Name,
                IsPrivate = r.IsPrivate
            });
        }

        public static RoomEntity ToRoomEntity(this RoomDto room)
        {
            return new RoomEntity()
            {
                Id = room.Id / 3 - 2,
                Name = room.Name,
                IsPrivate = room.IsPrivate
            };
        }
    }
}
