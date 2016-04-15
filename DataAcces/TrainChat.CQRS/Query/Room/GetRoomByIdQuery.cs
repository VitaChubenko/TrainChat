using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.Room
{
    internal class GetRoomByIdQuery : IQuery<RoomDto>
    {
        public readonly int Id;

        public GetRoomByIdQuery(int id)
        {
            Id = id;
        }
    }
}
