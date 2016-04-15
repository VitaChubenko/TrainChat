using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TrainChat.Model.Configuration;

namespace TrainChat.Model
{
    public class ChatContextReadOnly : DbContext
    {
        public ChatContextReadOnly()
            : base("ChatTrain")
        { }

        public DbQuery<UserEntity> Users
        {
            get { return Set<UserEntity>().AsNoTracking(); }
        }

        public DbQuery<RoomEntity> Rooms
        {
            get { return Set<RoomEntity>().AsNoTracking(); }
        }

        public DbQuery<UserRoomEntity> UserRoom
        {
            get { return Set<UserRoomEntity>().AsNoTracking(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new UserRoomConfiguration());
        }
        public override int SaveChanges()
        {
           // Throw if they try to call this
            throw new InvalidOperationException("This context is read-only.");
        }
    }
}
