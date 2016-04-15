namespace TrainChat.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniquenessOfNames : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RoomEntities", "Name", unique: true, name: "IX_NameUnique");
            CreateIndex("dbo.UserEntities", "Name", unique: true, name: "IX_NameUnique");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserEntities", "IX_NameUnique");
            DropIndex("dbo.RoomEntities", "IX_NameUnique");
        }
    }
}
