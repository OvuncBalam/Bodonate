namespace Bodonate.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTransfersFixMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transfers", "User_Id", c => c.Int());
            CreateIndex("dbo.Transfers", "User_Id");
            AddForeignKey("dbo.Transfers", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "User_Id", "dbo.Users");
            DropIndex("dbo.Transfers", new[] { "User_Id" });
            DropColumn("dbo.Transfers", "User_Id");
        }
    }
}
