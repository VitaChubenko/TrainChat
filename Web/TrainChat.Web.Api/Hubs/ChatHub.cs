﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using TrainChat.Web.Api.Models;
using System.Globalization;
using System.Web.Mvc;
using System.Threading;

namespace TrainChat.Web.Api.Hubs
{
    [Microsoft.AspNet.SignalR.Authorize]
    public class ChatHub : Hub
    {
        static readonly List<RoomChatModel> rooms = new List<RoomChatModel>();
        static List<UserChatModel> userChat = new List<UserChatModel>();
        static List<PrivateMessageHistoryModel> privateChat = new List<PrivateMessageHistoryModel>();
        static List<string> onlineUsers = new List<string>();
        private int roomId = 7;  
        private int userChatId = 0;
        private string thisUserName;
        List<string> allUsers = new List<string>();
        private string enDateTimeFormat = "MM/dd/yyyy hh:mm tt";
        private string ruDateTimeFormat = "dd/MM/yyyy hh:mm tt";
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
            string dt = "";
            if (CultureInfo.DefaultThreadCurrentCulture.Name == "en-US")
            {
                dt = local.ToString(enDateTimeFormat, new CultureInfo("en-US"));
            }
            else
            {               
                dt = local.ToString(ruDateTimeFormat, new CultureInfo("ru-RU"));           
            }
            
            Clients.Group(roomName).addMessage(userName, message, dt);
            if (isGroupMessage)
            {                
                AddMessageIntoRoom(roomName, userName, message, dt);
            }
            else
            {
                AddMessageIntoPrivateChat(userName, roomName, message, dt);
            }
        }

        public void ShowMessageHistory(string roomName, bool isGroupMessage)
        {
            //TimeZone zone = TimeZone.CurrentTimeZone;
            
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
                                DateTime local = message.MessageDateTime;
                                string dt = "";
                                if (CultureInfo.DefaultThreadCurrentCulture.Name == "en-US")
                                {
                                    dt = local.ToString(enDateTimeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                                }
                                else
                                {
                                    dt = local.ToString(ruDateTimeFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                                }
                                Clients.Caller.addMessage(message.User, message.Message, dt);
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
                            DateTime local = message.MessageDateTime;
                            string dt = "";
                            if (CultureInfo.DefaultThreadCurrentCulture.Name == "en-US")
                            {
                                dt = local.ToString(enDateTimeFormat, CultureInfo.CreateSpecificCulture("en-US"));
                            }
                            else
                            {
                                dt = local.ToString(ruDateTimeFormat, CultureInfo.CreateSpecificCulture("ru-RU"));
                            }
                            Clients.All.addMessage(message.User, message.Message, dt);
                        }
                    }
                }
            }
        }

        public void SetCulture(string cultureName)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
        }

        public void GetChatRoomsList()
        {
            var rr = rooms.Select(r => r.Name).ToList();
            rr.Add("FakeChat");
            var items = new HashSet<string>(rr);
            rr = items.ToList();
            ShowAllUsers(allUsers);
            var users = new HashSet<string>(allUsers);
            allUsers = users.ToList();
            Clients.All.getGetChatRoomsList(rr);
            Clients.All.showAllUsers(allUsers);
            Clients.All.colorOnlineUser(Context.User.Identity.Name, "#c4d5eb");
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
            Clients.All.colorOnlineUser(userName, "#c4d5eb");
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
            thisUserName = userName;
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
            Clients.All.colorOnlineUser(userName, "#c4d5eb");
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

        public void ColorAllOnlineUsers()
        {
            foreach(var name in onlineUsers)
            {
                Clients.All.colorOnlineUser(name, "#c4d5eb");
            }
        }

        public override Task OnConnected()
        {
            string name = "";
            if (Context.User.Identity.IsAuthenticated)
            {
                name = Context.User.Identity.Name;
            }
            onlineUsers.Add(name);
            Clients.All.colorOnlineUser(name, "#c4d5eb");           
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = "";
            if (Context.User.Identity.IsAuthenticated)
            {
                name = Context.User.Identity.Name;
            }
            onlineUsers.Remove(name);
            Clients.All.colorOnlineUser(name, "#FFFFFF");
            return base.OnDisconnected(stopCalled);
        }
    }
}