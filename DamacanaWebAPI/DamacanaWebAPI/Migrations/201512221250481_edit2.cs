namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts");
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Carts", "Id");
            AddForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts");
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "Id");
            AddForeignKey("dbo.Cart_Product", "CartId", "dbo.Carts", "Id", cascadeDelete: true);
        }
    }
}
