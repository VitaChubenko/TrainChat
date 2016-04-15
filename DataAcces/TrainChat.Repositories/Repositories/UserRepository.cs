using TrainChat.Model;

namespace TrainChat.Repositories.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>
    {
    //    private ChatContext db;
        public UserRepository(ChatContext context) : base (context)
    {
       
    }
    }
}
