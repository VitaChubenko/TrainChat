using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.Model.DTO;

namespace TrainChat.Service.Interfaces
{
    public interface IRoomService
    {
        //Queries
        IEnumerable<RoomDto> GetRooms();
        RoomDto GetByName(string name);
        RoomDto GetById(int id);

        //Commands
        void Create(RoomDto room);
        void Update(RoomDto room);
        void Delete(int id);
    }
}
