using System.Collections.Generic;

namespace TrainChat.Web.Api.Models
{
    public class RoomChatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        private List<UserChatModel> users;
        public List<UserChatModel> Users 
        {
            get { return users ?? new List<UserChatModel>(); }
            set { users = value; }
        }

        public List<MessageHistoryModel> Messages { get; set; }
    }
}