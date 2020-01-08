namespace MyWallet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable_Context : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Context",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UserId = c.Int(nullable: false),
                        CurrencyTypeId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.CurrencyType", t => t.CurrencyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CurrencyTypeId)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Context", "UserId", "dbo.User");
            DropForeignKey("dbo.Context", "CurrencyTypeId", "dbo.CurrencyType");
            DropForeignKey("dbo.Context", "CountryId", "dbo.Country");
            DropIndex("dbo.Context", new[] { "CountryId" });
            DropIndex("dbo.Context", new[] { "CurrencyTypeId" });
            DropIndex("dbo.Context", new[] { "UserId" });
            DropTable("dbo.Context");
        }
    }
}
