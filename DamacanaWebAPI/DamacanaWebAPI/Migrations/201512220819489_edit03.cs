namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases");
            DropPrimaryKey("dbo.Carts");
            DropPrimaryKey("dbo.Cart_Product");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Purchases");
            DropPrimaryKey("dbo.Purchase_Product");
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Cart_Product", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Purchases", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Purchase_Product", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "Id");
            AddPrimaryKey("dbo.Cart_Product", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Purchases", "Id");
            AddPrimaryKey("dbo.Purchase_Product", "Id");
            AddForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
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
            DropForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts");
            DropPrimaryKey("dbo.Purchase_Product");
            DropPrimaryKey("dbo.Purchases");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Cart_Product");
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Purchase_Product", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Purchases", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cart_Product", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Purchase_Product", "Id");
            AddPrimaryKey("dbo.Purchases", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Cart_Product", "Id");
            AddPrimaryKey("dbo.Carts", "Id");
            AddForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
