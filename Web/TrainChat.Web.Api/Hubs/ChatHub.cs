using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.SignalR;
using TrainChat.Web.Api.Models;

namespace TrainChat.Web.Api.Hubs
{
    public class ChatHub : Hub
    {
        static readonly List<RoomChatModel> rooms = new List<RoomChatModel>();

        static ChatHub()
        {
            rooms.Add(new RoomChatModel()
            {
                Id = 1,
                Name = "Base1",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-1.1" },
                    new UserChatModel() { Name = "Azat-1.2" },
                    new UserChatModel() { Name = "Azat-1.3" },
                    new UserChatModel() { Name = "Azat-1.4" }
                }
            });
            
            rooms.Add(new RoomChatModel()
            {
                Id = 2,
                Name = "Base2",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-2.1" },
                    new UserChatModel() { Name = "Azat-2.2" },
                    new UserChatModel() { Name = "Azat-2.3" },
                }
            });
            rooms.Add(new RoomChatModel()
            {
                Id = 3,
                Name = "Base3",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-3.1" },
                    new UserChatModel() { Name = "Azat-3.2" },
                    new UserChatModel() { Name = "Azat-3.3" },
                    new UserChatModel() { Name = "Azat-3.4" }
                }
            });
            rooms.Add(new RoomChatModel()
            {
                Id = 4,
                Name = "Base4",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-4.1" },
                    new UserChatModel() { Name = "Azat-4.2" },
                }
            });
            rooms.Add(new RoomChatModel()
            {
                Id = 5,
                Name = "Base5",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-1.1" },
                }
            });
            
            rooms.Add(new RoomChatModel()
            {
                Id = 6,
                Name = "PrivateChat",
                IsPrivate = true,
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat" }
                }
            });
        }
        public ChatHub()
        {

        }

        public void SendMessage(string roomName, string userName, string message, string dateTime)
        {
            Clients.Group(roomName).addMessage(userName, message, dateTime);
        }

        public void GetChatRoomsList()
        {
            var rr = rooms.Select(r => r.Name).ToList();
            rr.Add("FakeChat");
            Clients.Caller.getGetChatRoomsList(rr);
        }

        public IEnumerable<string> GetAllChatRoomNames()
        {
            return rooms.Select(x => x.Name).ToList();
        }

        public IEnumerable<RoomChatModel> GetAllChatRooms()
        {
            return rooms;
        }

        public void ConnectToRoomChat(string roomName, string userName)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                Clients.Caller.showAlert(String.Format("You are not authorized"));
                return;
            }
            var room = rooms.Find(r => r.Name == roomName);
            var connectionId = Context.ConnectionId;
            if (room == null)
            {
                Clients.Caller.showAlert(String.Format("The ChatRoom \"{0}\" doesn't exist", roomName));
                return;
            }

            if (room.IsPrivate)
            {
                if(room.Users.Exists(u => u.Name == userName))
                {
                    Groups.Add(connectionId, roomName);
                    Clients.Caller.onConnected(connectionId, userName, roomName, room.Users.Select(u => u.Name));
                    Clients.OthersInGroup(roomName).addServerMessage(String.Format("{0} joined to the ChatRoom", userName), DateTime.Now.ToUniversalTime());
                }
                else
                {
                    Clients.Caller.showAlert(String.Format("You don't have an access"));
                }

                return;
            }

            Groups.Add(connectionId, roomName);
            if (!room.Users.Any(x => x.Name == userName))
            {
                room.Users.Add(new UserChatModel() {Name = userName});
            }
            Clients.Caller.onConnected(connectionId, userName, roomName, room.Users.Select(u => u.Name));
            Clients.OthersInGroup(roomName).onNewUserConnected(room.Users.Select(u => u.Name));
            Clients.OthersInGroup(roomName).addServerMessage(String.Format("{0} joined to the ChatRoom", userName), DateTime.Now.ToUniversalTime());
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
            
                
        //        Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    if (item != null)
        //    {
        //        Users.Remove(item);
        //        var id = Context.ConnectionId;
        //        Clients.All.onUserDisconnected(id, item.Name);
        //    }
        //    return base.OnDisconnected(stopCalled);
        //}
    }
}