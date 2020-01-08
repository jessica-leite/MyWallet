namespace MyWallet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable_Context : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Context", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Context", "CurrencyTypeId", "dbo.CurrencyType");
            DropForeignKey("dbo.Context", "UserId", "dbo.User");
            DropIndex("dbo.Context", new[] { "UserId" });
            DropIndex("dbo.Context", new[] { "CurrencyTypeId" });
            DropIndex("dbo.Context", new[] { "CountryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Context", "CountryId");
            CreateIndex("dbo.Context", "CurrencyTypeId");
            CreateIndex("dbo.Context", "UserId");
            AddForeignKey("dbo.Context", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Context", "CurrencyTypeId", "dbo.CurrencyType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Context", "CountryId", "dbo.Country", "Id", cascadeDelete: true);
        }
    }
}
