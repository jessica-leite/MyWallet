namespace MyWallet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeys_Category_Context : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Category", "UserId");
            CreateIndex("dbo.Context", "UserId");
            CreateIndex("dbo.Context", "CurrencyTypeId");
            CreateIndex("dbo.Context", "CountryId");
            AddForeignKey("dbo.Category", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Context", "CountryId", "dbo.Country", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Context", "CurrencyTypeId", "dbo.CurrencyType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Context", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Context", "UserId", "dbo.User");
            DropForeignKey("dbo.Context", "CurrencyTypeId", "dbo.CurrencyType");
            DropForeignKey("dbo.Context", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Category", "UserId", "dbo.User");
            DropIndex("dbo.Context", new[] { "CountryId" });
            DropIndex("dbo.Context", new[] { "CurrencyTypeId" });
            DropIndex("dbo.Context", new[] { "UserId" });
            DropIndex("dbo.Category", new[] { "UserId" });
        }
    }
}
