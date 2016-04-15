using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.Room
{
    internal class GetRoomByNameQuery : IQuery<RoomDto>
    {
        public readonly string Name;

        public GetRoomByNameQuery(string name)
        {
            Name = name;
        }
    }
}
