namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Purchase_Id", c => c.Guid());
            AddColumn("dbo.Purchases", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Products", "Purchase_Id");
            CreateIndex("dbo.Purchases", "UserId");
            AddForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases", "Id");
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Purchase_Id" });
            DropColumn("dbo.Purchases", "UserId");
            DropColumn("dbo.Purchases", "CreatedOn");
            DropColumn("dbo.Products", "Purchase_Id");
        }
    }
}
