using TrainChat.Model;

namespace TrainChat.Repositories.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity>
    {
      //  private ChatContext db;
        public RoleRepository(ChatContext context) : base (context)
        {
            
        }

        
    }
}
