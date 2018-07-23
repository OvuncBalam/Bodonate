namespace Bodonate.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Genre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Genre_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donaters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tracknumber = c.Int(nullable: false),
                        TransferDate = c.DateTime(nullable: false),
                        UserDonated_Id = c.Int(),
                        UserRequested_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donaters", t => t.UserDonated_Id)
                .ForeignKey("dbo.Requesters", t => t.UserRequested_Id)
                .Index(t => t.UserDonated_Id)
                .Index(t => t.UserRequested_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Confirmpassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "UserRequested_Id", "dbo.Requesters");
            DropForeignKey("dbo.Transfers", "UserDonated_Id", "dbo.Donaters");
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Transfers", new[] { "UserRequested_Id" });
            DropIndex("dbo.Transfers", new[] { "UserDonated_Id" });
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Transfers");
            DropTable("dbo.Requesters");
            DropTable("dbo.Donaters");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
