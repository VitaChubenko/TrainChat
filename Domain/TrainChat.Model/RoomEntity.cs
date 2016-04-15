using System.Collections.Generic;

namespace TrainChat.Model
{
    public class RoomEntity : Entity<int>
    {

        public string Name { get; set; }
        public bool IsPrivate { get; set; }

        // UserEntity to RoomEntity through UserRoomEntity (many to many)
        public virtual ICollection<UserRoomEntity> RoomUser { get; set; }
        public RoomEntity()
        {
            RoomUser = new List<UserRoomEntity>();
        }

        //Room's creator
        public int CreatorId { get; set; }
        public UserEntity Creator { get; set; }
    }
}
