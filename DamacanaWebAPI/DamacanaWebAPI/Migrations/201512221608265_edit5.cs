namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Purchase_Product");
            AlterColumn("dbo.Purchase_Product", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Purchase_Product", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Purchase_Product");
            AlterColumn("dbo.Purchase_Product", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Purchase_Product", "Id");
        }
    }
}
