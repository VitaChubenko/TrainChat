using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TrainChat.CQRS.Helpers;
using TrainChat.Model;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.User
{
    public class UserQueryHandler : 
        IQueryHandler<GetAllUsersQuery, List<UserDto>>,
        IQueryHandler<GetUserByLoginQuery, UserDto>,
        IQueryHandler<GetUserByNameQuery, UserDto>,
        IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ChatContextReadOnly db;

        public UserQueryHandler(ChatContextReadOnly db)
        {
            this.db = db;
        }
        
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

        public UserDto Handle(GetUserByIdQuery query)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == query.Id/3 - 2);
            return user == null ? null : user.ToUserDto();
        }

        public IQueryable<UserDto> GetUsers(Expression<Func<UserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
            //return db.Users.Where(predicate).Select(u => new UserDto());
        }
    }
}
