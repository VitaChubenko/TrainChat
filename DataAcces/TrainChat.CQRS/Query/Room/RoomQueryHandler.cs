using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.CQRS.Helpers;
using TrainChat.Model;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.Query.Room
{
    internal class RoomQueryHandler :
        IQueryHandler<GetAllRoomsQuery, IEnumerable<RoomDto>>,
        IQueryHandler<GetRoomByNameQuery, RoomDto>,
        IQueryHandler<GetRoomByIdQuery, RoomDto>,
        IQueryHandler<GetNumberOfUsersQuery, int?>
    {
        private readonly ChatContextReadOnly db;

        public RoomQueryHandler(ChatContextReadOnly db)
        {
            this.db = db;
        }
        public IEnumerable<RoomDto> Handle(GetAllRoomsQuery query)
        {
            return db.Rooms.ToRoomDtoList();
        }

        public RoomDto Handle(GetRoomByNameQuery query)
        {
            var room = db.Rooms.FirstOrDefault(r => r.Name == query.Name);
            return room == null ? null : room.ToRoomDto();
        }

        public RoomDto Handle(GetRoomByIdQuery query)
        {
            var room = db.Rooms.FirstOrDefault(r => r.Id == query.Id / 3 - 2);
            return room == null ? null : room.ToRoomDto();
        }

        public int? Handle(GetNumberOfUsersQuery query)
        {
            var room = db.Rooms.FirstOrDefault(r => r.Name == query.Name);

            if (room == null)
            {
                return null;
            }
            else
            {
                return room.RoomUser.Count;
            }

        }
    }
}
