using System;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.WriteModels
{
    public interface IUserWriteModel : IDisposable
    {
        void Create(UserDto user);
        void Update(UserDto user);
        void Delete(int id);
    }
}
