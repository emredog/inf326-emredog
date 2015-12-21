namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases");
            DropIndex("dbo.Products", new[] { "Purchase_Id" });
            DropColumn("dbo.Products", "Purchase_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Purchase_Id", c => c.Guid());
            CreateIndex("dbo.Products", "Purchase_Id");
            AddForeignKey("dbo.Products", "Purchase_Id", "dbo.Purchases", "Id");
        }
    }
}
