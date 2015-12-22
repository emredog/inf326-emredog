namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products");
            DropIndex("dbo.Purchase_Product", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Purchase_Product", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.Purchase_Product", "ProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Purchase_Product", "ProductId");
            AddForeignKey("dbo.Purchase_Product", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase_Product", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchase_Product", new[] { "ProductId" });
            AlterColumn("dbo.Purchase_Product", "ProductId", c => c.Guid());
            RenameColumn(table: "dbo.Purchase_Product", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Purchase_Product", "Product_Id");
            AddForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products", "Id");
        }
    }
}
