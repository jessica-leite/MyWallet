namespace MyWallet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable_Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ContextId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Context", t => t.ContextId, cascadeDelete: true)
                .Index(t => t.ContextId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ContextId", "dbo.Context");
            DropIndex("dbo.Category", new[] { "ContextId" });
            DropTable("dbo.Category");
        }
    }
}
