namespace TrainChat.Model.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class DropRolesTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RoleEntities");
        }
        
        public override void Down()
        {
        }
    }
}
