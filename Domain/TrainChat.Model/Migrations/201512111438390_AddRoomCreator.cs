namespace TrainChat.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomCreator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities");
            AddColumn("dbo.RoomEntities", "CreatorId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoomEntities", "CreatorId");
            AddForeignKey("dbo.RoomEntities", "CreatorId", "dbo.UserEntities", "Id");
            AddForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.RoomEntities", "CreatorId", "dbo.UserEntities");
            DropIndex("dbo.RoomEntities", new[] { "CreatorId" });
            DropColumn("dbo.RoomEntities", "CreatorId");
            AddForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities", "Id", cascadeDelete: true);
        }
    }
}
