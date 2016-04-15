using TrainChat.CQRS.Commands.User;
using TrainChat.CQRS.UnitOfWork;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.WriteModels
{
    public class UserWriteModel : IUserWriteModel
    {
        private UserCommandHandler userCommandHandler;
        private IUnitOfWork uow;

        public UserWriteModel(IUnitOfWork uow)
        {
            this.uow = uow;
            userCommandHandler = new UserCommandHandler(this.uow.Context);
        }
        
        public void Create(UserDto user)
        {
            var command = new CreateUserCommand(user);
            userCommandHandler.Handle(command);
            uow.Save();
        }

        public void Update(UserDto user)
        {
            var command = new UpdateUserCommand(user);
            userCommandHandler.Handle(command);
            uow.Save();
        }

        public void Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            userCommandHandler.Handle(command);
            uow.Save();
        }

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
