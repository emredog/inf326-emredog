namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crosstables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart_Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        amount = c.Int(nullable: false),
                        CartId = c.Guid(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.CartId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Purchase_Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        amount = c.Int(nullable: false),
                        PurchaseId = c.Guid(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.PurchaseId)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Carts", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Carts", "UserId");
            AddForeignKey("dbo.Carts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Purchase_Product", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Cart_Product", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts");
            DropIndex("dbo.Purchase_Product", new[] { "Product_Id" });
            DropIndex("dbo.Purchase_Product", new[] { "PurchaseId" });
            DropIndex("dbo.Cart_Product", new[] { "Product_Id" });
            DropIndex("dbo.Cart_Product", new[] { "CartId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropColumn("dbo.Carts", "UserId");
            DropTable("dbo.Purchase_Product");
            DropTable("dbo.Cart_Product");
        }
    }
}
