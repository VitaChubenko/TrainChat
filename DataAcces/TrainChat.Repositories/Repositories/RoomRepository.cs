using TrainChat.Model;

namespace TrainChat.Repositories.Repositories
{
    public class RoomRepository : BaseRepository<RoomEntity>
    {
        private ChatContext db;
        public RoomRepository(ChatContext context) : base (context)
        {
            this.db = context;
        }
    }
}
