using System;
using System.Collections.Generic;
using TrainChat.Model.DTO;


namespace TrainChat.Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        //Queries
        List<UserDto> GetUsers();
        UserDto GetByLogin(string login);
        UserDto GetById(int id);

        //Commands
        void Create(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
    }
}
