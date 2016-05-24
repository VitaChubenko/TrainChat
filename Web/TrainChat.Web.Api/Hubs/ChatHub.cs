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
        static List<UserChatModel> userChat = new List<UserChatModel>();
        static List<PrivateMessageHistoryModel> privateChat = new List<PrivateMessageHistoryModel>();
        //public List<UserChatModel> usersList = new List<UserChatModel>();
        private int roomId = 7;  //6
        private int userChatId = 0;
        List<string> allUsers = new List<string>(); //+online/offline
        static ChatHub()
        {
            rooms.Add(new RoomChatModel()
            {
                Id = 1,
                Name = "Base1",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-1.1", IsBanned = false },
                    new UserChatModel() { Name = "Azat-1.2", IsBanned = false },
                    new UserChatModel() { Name = "Azat-1.3", IsBanned = false },
                    new UserChatModel() { Name = "Azat-1.4", IsBanned = false }
                },
                Messages = new List<MessageHistoryModel>()
            });
            
            rooms.Add(new RoomChatModel()
            {
                Id = 2,
                Name = "Base2",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-2.1", IsBanned = false },
                    new UserChatModel() { Name = "Azat-2.2", IsBanned = false },
                    new UserChatModel() { Name = "Azat-2.3", IsBanned = false },
                },
                Messages = new List<MessageHistoryModel>()
            });
            rooms.Add(new RoomChatModel()
            {
                Id = 3,
                Name = "Base3",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-3.1", IsBanned = false },
                    new UserChatModel() { Name = "Azat-3.2", IsBanned = false },
                    new UserChatModel() { Name = "Azat-3.3", IsBanned = false },
                    new UserChatModel() { Name = "Azat-3.4", IsBanned = false }
                },
                Messages = new List<MessageHistoryModel>()
            });
            rooms.Add(new RoomChatModel()
            {
                Id = 4,
                Name = "Base4",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-4.1", IsBanned = false },
                    new UserChatModel() { Name = "Azat-4.2", IsBanned = false },
                },
                Messages = new List<MessageHistoryModel>()
            });
            rooms.Add(new RoomChatModel()
            {
                Id = 5,
                Name = "Base5",
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat-1.1", IsBanned = false },
                },
                Messages = new List<MessageHistoryModel>()
            });
            
            rooms.Add(new RoomChatModel()
            {
                Id = 6,
                Name = "PrivateChat",
                IsPrivate = true,
                Users = new List<UserChatModel>()
                {
                    new UserChatModel() { Name = "Azat", IsBanned = false }
                },
                Messages = new List<MessageHistoryModel>()
            });

            rooms.Add(new RoomChatModel()
            {
                Id = 7,
                Name = "NewRoom",
                IsPrivate = false,
                Users = new List<UserChatModel>(),
                Messages = new List<MessageHistoryModel>()
            });
        }

        public void AddNewRoom(string name, bool isPrivate)
        {
            roomId++;
            rooms.Add(new RoomChatModel()
            {
                Id = roomId,
                Name = name,
                IsPrivate = isPrivate,
                Users = new List<UserChatModel>(),
                Messages = new List<MessageHistoryModel>()
            });
        }

        public void AddPrivateChat(string user1, string user2)
        {
            privateChat.Add(new PrivateMessageHistoryModel()
            {
                UserName1 = user1,
                UserName2 = user2,
                PrivateMessages = new List<MessageHistoryModel>()
            });
        }

        public PrivateMessageHistoryModel FindPrivateChat(string user1, string user2)
        {
            PrivateMessageHistoryModel thisChat = new PrivateMessageHistoryModel();
            foreach (var chat in privateChat)
            {
                if ((chat.UserName1 == user1) && (chat.UserName2 == user2)||
                    (chat.UserName1 == user2) && (chat.UserName2 == user1))
                {
                    thisChat = chat;
                }
            }
            return thisChat;
        }

        public void AddNewRoom(RoomChatModel roomsChatModel)
        {
            rooms.Add(roomsChatModel);
        }

        public void DeleteRoomById(int id)
        {
            RoomChatModel roomChatModel = new RoomChatModel();
            foreach (var room in rooms)
            {
                if (room.Id == id)
                {
                    roomChatModel = room;
                }
            }
            rooms.Remove(roomChatModel);
        }

        public string GetRoomNameById(int id)
        {
            string name ="";
            foreach (var room in rooms)
            {
                if (room.Id == id)
                {
                    name = room.Name;
                }
            }
            return name;
        }

        public int GetRoomIdByName(string name)
        {
            int id = 0;
            foreach (var room in rooms)
            {
                if (room.Name == name)
                {
                    id = room.Id;
                }
            }
            return id;
        }

        public void AddUser(RoomChatModel room, UserChatModel user)
        {
            user.IsBanned = false;
            room.Users.Add(user);            
        }

        public List<UserChatModel> GetUsers()
        {
            foreach (var room in rooms)
            {
                foreach (var user in room.Users)
                {
                    userChat.Add(new UserChatModel
                    {
                        Id = userChatId++,
                        Name = user.Name,
                        IsBanned = user.IsBanned
                    });
                }
            }
            var items = new HashSet<UserChatModel>(userChat);
            userChat = new List<UserChatModel>(items);
            return userChat;
        }
        public void AddMessageIntoRoom(string roomName, string userName, string message, string dateTime)
        {
            foreach (var room in rooms)
            {
                if (room.Name == roomName)
                {
                    room.Messages.Add(new MessageHistoryModel()
                    {
                        User = userName,
                        Message = message,
                        MessageDateTime = Convert.ToDateTime(dateTime)
                    });
                }
            }
        }

        public void AddMessageIntoPrivateChat(string userName, string opponentName, string message, string dateTime)
        {
            foreach (var chat in privateChat)
            {
                if ((chat.UserName1 == userName) && (chat.UserName2 == opponentName) ||
                    (chat.UserName1 == opponentName) && (chat.UserName2 == userName))
                {
                    chat.PrivateMessages.Add(new MessageHistoryModel()
                    {
                        User = userName,
                        Message = message,
                        MessageDateTime = Convert.ToDateTime(dateTime)
                    });
                }
            }
        }

        public bool IsPrivateChatExists(string userName, string opponentName)
        {
            bool isPrivateChatExists = false;
            foreach (var chat in privateChat)
            {
                if ((chat.UserName1 == userName) && (chat.UserName2 == opponentName))
                {
                    isPrivateChatExists = true;
                    break;
                }
            }
            return isPrivateChatExists;
        }

        public void ShowAllUsers(List<string> allUsers)
        {        
            foreach (var room in rooms)
            {
                foreach (var user in room.Users)
                {
                    if (user.IsBanned == false)
                    {
                        allUsers.Add(user.Name);
                    }
                }
            }
        }

        public ChatHub()
        {

        }

        public void SendMessage(string roomName, string userName, string message, bool isGroupMessage)
        {
            if (!isGroupMessage && !IsPrivateChatExists(userName, roomName))
            {
                AddPrivateChat(userName, roomName);
            }
            DateTime dateTime = DateTime.Now.ToUniversalTime();
            TimeZone zone = TimeZone.CurrentTimeZone;
            DateTime local = zone.ToLocalTime(dateTime);
            Clients.Group(roomName).addMessage(userName, message, local.ToString("dd/MM/yyyy hh:mm:ss"));
            if (isGroupMessage)
            {                
                AddMessageIntoRoom(roomName, userName, message, dateTime.ToString("dd/MM/yyyy hh:mm:ss"));
            }
            else
            {
                AddMessageIntoPrivateChat(userName, roomName, message, dateTime.ToString("dd/MM/yyyy hh:mm:ss"));
            }
        }

        public void ShowMessageHistory(string roomName, bool isGroupMessage)
        {
            TimeZone zone = TimeZone.CurrentTimeZone;
            
            if (isGroupMessage)
            {
                foreach (var room in rooms)
                {
                    if (room.Name == roomName)
                    {
                        if (room.Messages.Count > 0)
                        {
                            foreach (var message in room.Messages)
                            {
                                DateTime local = zone.ToLocalTime(message.MessageDateTime);
                                Clients.All.addMessage(message.User, message.Message, local.ToString("dd/MM/yyyy hh:mm:ss"));
                            }
                            break;
                        }
                        else break;
                    }
                }
            }
            else
            {
                foreach (var chat in privateChat)
                {
                    if (chat.UserName2 == roomName)
                    {
                        foreach (var message in chat.PrivateMessages)
                        {
                            DateTime local = zone.ToLocalTime(message.MessageDateTime);
                            Clients.All.addMessage(message.User, message.Message, local.ToString("dd/MM/yyyy hh:mm:ss"));
                        }
                    }
                }
            }
        }

        public void GetChatRoomsList()
        {
            var rr = rooms.Select(r => r.Name).ToList();
            rr.Add("FakeChat");
            var items = new HashSet<string>(rr);
            rr = items.ToList();
            Clients.Caller.getGetChatRoomsList(rr);
        }

        public void AddUserToRoom(string roomName, string userName)
        {
            List<string> users = new List<string>();
            foreach (var room in rooms)
            {
                if((room.Name == roomName)&&(!IsInRoom(room, userName)))
                {
                    room.Users.Add(new UserChatModel
                    {
                        Id = room.Users.Count + 1,
                        Name = userName,
                        IsBanned = false
                    });
                    users = new List<string>(room.Users.Select(u => u.Name));
                    Clients.All.onNewUserConnected(users);
                    break;
                }
            }           
        }

        public bool IsInRoom(RoomChatModel room, string userName)
        {
            bool inRoom = false;
            foreach(var user in room.Users)
            {
                if (user.Name == userName)
                {
                    inRoom = true;
                    break;
                }
            }
            return inRoom;
        }

        public void SetBan(int id, bool isBanned)
        {
            List<UserChatModel> userChat = GetUsers();
            foreach (var user in userChat)
            {
                if(user.Id == id)
                {
                    user.IsBanned = isBanned;
                    break;
                }
            }
            RefreshRooms(userChat);
        }

        public void RefreshRooms(List<UserChatModel> userChat)
        {
            foreach (var room in rooms)
            {
                foreach (var roomUser in room.Users)
                {
                    foreach(var user in userChat)
                    {
                        if (user.Name == roomUser.Name)
                        {
                            roomUser.IsBanned = user.IsBanned;
                            break;
                        }
                    }
                }
            }
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
            ShowAllUsers(allUsers);
            var items = new HashSet<string>(allUsers);
            allUsers = items.ToList();
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
                    Clients.Caller.onConnected(connectionId, userName, roomName, room.Users.Select(u => u.Name), allUsers);
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
            Clients.Caller.onConnected(connectionId, userName, roomName, room.Users.Select(u => u.Name), allUsers);
            Clients.OthersInGroup(roomName).onNewUserConnected(room.Users.Select(u => u.Name));
            Clients.OthersInGroup(roomName).addServerMessage(String.Format("{0} joined to the ChatRoom", userName), DateTime.Now.ToUniversalTime());
        }

        public void ConnectToPrivateChat(string roomName, string userName)
        {
            if (!IsPrivateChatExists(userName, roomName))
            {
                AddPrivateChat(userName, roomName);
            }
            var connectionId = Context.ConnectionId;
            Groups.Add(connectionId, roomName);      
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