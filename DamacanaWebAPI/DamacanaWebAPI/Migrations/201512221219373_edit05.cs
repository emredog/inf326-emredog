namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases");
            DropPrimaryKey("dbo.Cart_Product");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Purchases");
            AlterColumn("dbo.Cart_Product", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Purchases", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Cart_Product", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Purchases", "Id");
            AddForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products");
            DropPrimaryKey("dbo.Purchases");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Cart_Product");
            AlterColumn("dbo.Purchases", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Cart_Product", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Purchases", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Cart_Product", "Id");
            AddForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products", "Id");
        }
    }
}
