namespace MyWallet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable_BankAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Context", "IsMainContext", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccount", "UserId", "dbo.User");
            DropIndex("dbo.BankAccount", new[] { "UserId" });
            DropColumn("dbo.Context", "IsMainContext");
            DropTable("dbo.BankAccount");
        }
    }
}
