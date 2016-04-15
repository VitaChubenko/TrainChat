using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.CQRS.Helpers;
using TrainChat.Model;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.User
{
    public class UserQueryHandler : 
        IQueryHandler<GetAllUsersQuery, List<UserDto>>,
        IQueryHandler<GetUserByLoginQuery, UserDto>,
        IQueryHandler<GetUserByNameQuery, UserDto>
    {
        private readonly ChatContext db = new ChatContext();
        public List<UserDto> Handle(GetAllUsersQuery query)
        {
            return db.Users.ToUserDtoList().ToList();
        }

        public UserDto Handle(GetUserByLoginQuery query)
        {
            var user = db.Users.FirstOrDefault(u => u.Login == query.Login);
            return user == null ? null : user.ToUserDto();
        }

        public UserDto Handle(GetUserByNameQuery query)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == query.Name);
            return user == null ? null : user.ToUserDto();
        }
    }
}
