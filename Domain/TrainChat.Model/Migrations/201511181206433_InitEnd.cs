namespace TrainChat.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitEnd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Login = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 150),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleEntities", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoomEntities",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoomId })
                .ForeignKey("dbo.RoomEntities", t => t.RoomId)
                .ForeignKey("dbo.UserEntities", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.RoomEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsPrivate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEntities", "RoleId", "dbo.RoleEntities");
            DropForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.UserRoomEntities", "RoomId", "dbo.RoomEntities");
            DropIndex("dbo.UserRoomEntities", new[] { "RoomId" });
            DropIndex("dbo.UserRoomEntities", new[] { "UserId" });
            DropIndex("dbo.UserEntities", new[] { "RoleId" });
            DropTable("dbo.RoomEntities");
            DropTable("dbo.UserRoomEntities");
            DropTable("dbo.UserEntities");
            DropTable("dbo.RoleEntities");
        }
    }
}
