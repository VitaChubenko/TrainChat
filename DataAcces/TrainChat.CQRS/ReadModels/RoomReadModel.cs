using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainChat.CQRS.Query.Room;
using TrainChat.CQRS.Query.User;
using TrainChat.CQRS.UnitOfWork;
using TrainChat.Model.DTO;

namespace TrainChat.CQRS.ReadModels
{
    public class RoomReadModel : IRoomReadModel
    {
        private readonly RoomQueryHandler roomQueryHandler;
        private IUnitOfWork uow;

        public RoomReadModel(IUnitOfWork uow)
        {
            this.uow = uow;
            roomQueryHandler = new RoomQueryHandler(this.uow.ReadOnlyContext);
        }

        public IEnumerable<RoomDto> GetRooms()
        {
            var query = new GetAllRoomsQuery();
            return roomQueryHandler.Handle(query);
        }

        public RoomDto GetRoomByName(string name)
        {
            var query = new GetRoomByNameQuery(name);
            return roomQueryHandler.Handle(query);
        }

        public RoomDto GetRoomById(int id)
        {
            var query = new GetRoomByIdQuery(id);
            return roomQueryHandler.Handle(query); ;
        }

        public int? GetNumberOfUsers(string name)
        {
            var query = new GetNumberOfUsersQuery(name);
            return roomQueryHandler.Handle(query);
        }
    }
}
