using System.Data.Entity;
using TrainChat.Model.Configuration;

namespace TrainChat.Model
{
    class MyChatContextInitializer : DropCreateDatabaseAlways<ChatContext>
    {
        protected override void Seed(ChatContext db)
        {
            /*{
            RoleEntity rs1 = new RoleEntity { Name = "Admin", Description = "MainUser", Id = 1};
            RoleEntity rs2 = new RoleEntity { Name = "User", Description = "CommonUser", Id = 2};
            db.Roles.Add(rs1);
            db.Roles.Add(rs2);
            db.SaveChanges();*/

            //UserEntity u1 = new UserEntity {Name = "Frank", Login = "Jardin", Password = "qaz1", Role = Roles.Admin};
            //UserEntity u2 = new UserEntity {Name = "Beely", Login = "Greenfield", Password = "wsx1", Role = Roles.Moderator};
            //UserEntity u3 = new UserEntity {Name = "Bob", Login = "Nescafe", Password = "edc1", Role = Roles.User};
            //db.Users.AddRange(new List<UserEntity> {u1, u2, u3});
            //db.SaveChanges();

            /*RoomEntity r1 = new RoomEntity {Name = "BlackRoom", IsPrivate = false};
            RoomEntity r2 = new RoomEntity {Name = "WhiteRoom", IsPrivate = false};

            db.Rooms.Add(r1);
            db.Rooms.Add(r2);
            db.SaveChanges();*/

        }

    }
    public class ChatContext : DbContext
    {
        //static ChatContext()
        //{
        //    Database.SetInitializer<ChatContext>(new MyChatContextInitializer());
        //}

        public ChatContext()
            : base("ChatTrain")
        { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        //public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoomEntity> UserRoom { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new UserRoomConfiguration());

        }
    }

}
