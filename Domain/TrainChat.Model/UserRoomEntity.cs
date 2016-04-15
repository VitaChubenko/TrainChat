namespace TrainChat.Model
{
   public class UserRoomEntity
    {
       public int UserId { get; set; }
       public UserEntity User { get; set; }


       public int RoomId { get; set; }
       public RoomEntity Room { get; set; }
    }
}
