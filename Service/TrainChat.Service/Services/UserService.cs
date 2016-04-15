using System.Collections.Generic;
using System.Linq;
using TrainChat.CQRS.ReadModels;
using TrainChat.CQRS.WriteModels;
using TrainChat.Model.DTO;
using TrainChat.Service.Interfaces;

namespace TrainChat.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadModel userRead;
        private readonly IUserWriteModel userWrite;

        //Queries
        public UserService(IUserReadModel userRead, IUserWriteModel userWrite)
        {
            this.userRead = userRead;
            this.userWrite = userWrite;
        }

        public List<UserDto> GetUsers()
        {
            return userRead.GetUsers().ToList();
        }

        public UserDto GetByLogin(string login)
        {
            return userRead.GetUserByLogin(login);
        }

        public UserDto GetById(int id)
        {
            return userRead.GetUserById(id);
        }

        //Commands
        public void Create(UserDto user)
        {
            userWrite.Create(user);
        }

        public void Update(UserDto user)
        {
            userWrite.Update(user);
        }

        public void Delete(int id)
        {
            userWrite.Delete(id);
        }

        public void Dispose()
        {
            userRead.Dispose();
            userWrite.Dispose();
        }
    }
}
