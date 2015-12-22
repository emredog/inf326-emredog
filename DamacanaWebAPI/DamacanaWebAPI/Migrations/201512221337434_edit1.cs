namespace DamacanaWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "LastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "LastModified");
            DropColumn("dbo.Carts", "CreatedOn");
        }
    }
}
