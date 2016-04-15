using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainChat.Web.Api.Models
{
    public class RoomChatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public List<UserChatModel> Users 
        {
            get { return users ?? new List<UserChatModel>(); }
            set { users = value; }
        }

        private List<UserChatModel> users;
    }
}