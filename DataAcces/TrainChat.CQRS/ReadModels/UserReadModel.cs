using System.Collections.Generic;
using System.Linq;
using TrainChat.CQRS.Query.User;
using TrainChat.CQRS.UnitOfWork;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.ReadModels
{
    public class UserReadModel : IUserReadModel
    {
        private UserQueryHandler userQueryHandler;
        private IUnitOfWork uow;
        public UserReadModel(IUnitOfWork uow)
        {
            this.uow = uow;
            userQueryHandler = new UserQueryHandler(this.uow.ReadOnlyContext);
        }

        public List<UserDto> GetUsers()
        {
            var query = new GetAllUsersQuery();
            return userQueryHandler.Handle(query).ToList();
        }

        public UserDto GetUserByLogin(string login)
        {
            var query = new GetUserByLoginQuery(login);
            return userQueryHandler.Handle(query);
        }

        public UserDto GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            return userQueryHandler.Handle(query);
        }
        
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
