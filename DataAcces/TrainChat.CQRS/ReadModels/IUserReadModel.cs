using System;
using System.Collections.Generic;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.ReadModels
{
    public interface IUserReadModel : IDisposable
    {
        List<UserDto> GetUsers();
        UserDto GetUserByLogin(string login);
        UserDto GetUserById(int id);
    }
}
