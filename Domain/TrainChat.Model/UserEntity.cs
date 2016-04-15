using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainChat.Model
{
    public class UserEntity : Entity<int>
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        // UserEntity to RoomEntity through UserRoomEntity (many to many)
        public virtual ICollection<UserRoomEntity> UserRoom { get; set; }
        
        // List of rooms created by User
        public virtual ICollection<RoomEntity> CreatedRooms { get; set; }
        

        //public int RoleId { get; set; }
        //public RoleEntity Role { get; set; }
    }
}
