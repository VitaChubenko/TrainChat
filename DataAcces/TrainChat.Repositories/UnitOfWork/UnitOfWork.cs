using System;
using TrainChat.Model;
using TrainChat.Repositories.Repositories;

namespace TrainChat.Repositories.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ChatContext context = new ChatContext();
        private RoleRepository roleRepository;
        private RoomRepository roomRepository;
        private UserRepository userRepository;

        public RoleRepository Role
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(context);
                return roleRepository;
            }
        }

        public RoomRepository Room
        {
            get
            {
                if (roomRepository == null)
                    roomRepository = new RoomRepository(context);
                return roomRepository;
            }
        }

        public UserRepository User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
