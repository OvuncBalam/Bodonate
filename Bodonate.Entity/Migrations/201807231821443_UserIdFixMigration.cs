namespace Bodonate.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdFixMigration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Donaters", "UserId");
            CreateIndex("dbo.Requesters", "UserId");
            AddForeignKey("dbo.Donaters", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Requesters", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requesters", "UserId", "dbo.Users");
            DropForeignKey("dbo.Donaters", "UserId", "dbo.Users");
            DropIndex("dbo.Requesters", new[] { "UserId" });
            DropIndex("dbo.Donaters", new[] { "UserId" });
        }
    }
}
