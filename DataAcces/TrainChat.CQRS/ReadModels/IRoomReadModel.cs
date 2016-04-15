using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.ReadModels
{
    public interface IRoomReadModel
    {
        IEnumerable<RoomDto> GetRooms();
        RoomDto GetRoomByName(string name);
        RoomDto GetRoomById(int id);
        int? GetNumberOfUsers(string name);
    }
}
