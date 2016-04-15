using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.CQRS.ReadModels;
using TrainChat.CQRS.WriteModels;
using TrainChat.Model.DTO;
using TrainChat.Service.Interfaces;

namespace TrainChat.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomReadModel roomRead;
        public IEnumerable<RoomDto> GetRooms()
        {
            throw new NotImplementedException();
        }

        public RoomDto GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public RoomDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(RoomDto room)
        {
            throw new NotImplementedException();
        }

        public void Update(RoomDto room)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
