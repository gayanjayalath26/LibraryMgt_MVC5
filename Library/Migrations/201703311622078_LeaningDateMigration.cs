namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaningDateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lends", "LendingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lends", "ExpiredDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lends", "ExpiredDate");
            DropColumn("dbo.Lends", "LendingDate");
        }
    }
}
