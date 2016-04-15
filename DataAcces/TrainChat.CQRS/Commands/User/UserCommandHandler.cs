using System.Collections.Generic;
using System.Data.Entity;
using TrainChat.CQRS.Helpers;
using TrainChat.Model;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Commands.User
{
    public class UserCommandHandler :
        ICommandHandler<CreateUserCommand, UserDto>,
        ICommandHandler<UpdateUserCommand, UserDto>,
        ICommandHandler<DeleteUserCommand, int>

    {
        private ChatContext db;

        public UserCommandHandler(ChatContext db)
        {
            this.db = db;
        }

        public UserDto Handle(CreateUserCommand command)
        {
            return db.Users.Add(command.User.ToUserEntity()).ToUserDto();
        }

        public UserDto Handle(UpdateUserCommand command)
        {
            var user = command.User.ToUserEntity();
            var updatedUser = db.Users.Attach(user);
            db.Entry(user).State = EntityState.Modified;

            return updatedUser.ToUserDto();
        }

        public int Handle(DeleteUserCommand command)
        {
            var userEntity = db.Users.Find(command.Id/3 - 2);
            if (userEntity != null)
            {
                return db.Users.Remove(userEntity).Id;
            }
            else
            {
                throw new KeyNotFoundException("The UserEntity doesn't exist");
            }
        }
    }
}
