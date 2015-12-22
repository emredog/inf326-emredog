namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products");
            DropIndex("dbo.Cart_Product", new[] { "Product_Id" });
            RenameColumn(table: "dbo.Cart_Product", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.Cart_Product", "ProductId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Cart_Product", "ProductId");
            AddForeignKey("dbo.Cart_Product", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart_Product", "ProductId", "dbo.Products");
            DropIndex("dbo.Cart_Product", new[] { "ProductId" });
            AlterColumn("dbo.Cart_Product", "ProductId", c => c.Guid());
            RenameColumn(table: "dbo.Cart_Product", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.Cart_Product", "Product_Id");
            AddForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products", "Id");
        }
    }
}
