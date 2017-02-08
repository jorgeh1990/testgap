namespace TestGAP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsMig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "address", c => c.String());
            AlterColumn("dbo.Stores", "name", c => c.String());
        }
    }
}
