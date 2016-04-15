using System.Data.Entity.ModelConfiguration;

namespace TrainChat.Model.Configuration
{
    class UserRoomConfiguration : EntityTypeConfiguration<UserRoomEntity>
    {
        public UserRoomConfiguration()
        {
            HasKey(t => new {t.UserId, t.RoomId});
        }
    }
}
