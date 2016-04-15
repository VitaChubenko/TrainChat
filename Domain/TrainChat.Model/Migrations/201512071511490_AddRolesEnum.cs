namespace TrainChat.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddRolesEnum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEntities", "RoleId", "dbo.RoleEntities");
            DropForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities");
            DropIndex("dbo.UserEntities", new[] { "RoleId" });
            AddColumn("dbo.UserEntities", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.RoleEntities", "Name", c => c.String());
            AlterColumn("dbo.RoleEntities", "Description", c => c.String());
            AddForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities", "Id", cascadeDelete: true);
            DropColumn("dbo.UserEntities", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserEntities", "RoleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities");
            AlterColumn("dbo.RoleEntities", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.RoleEntities", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.UserEntities", "Role");
            CreateIndex("dbo.UserEntities", "RoleId");
            AddForeignKey("dbo.UserRoomEntities", "UserId", "dbo.UserEntities", "Id");
            AddForeignKey("dbo.UserEntities", "RoleId", "dbo.RoleEntities", "Id");
        }
    }
}
