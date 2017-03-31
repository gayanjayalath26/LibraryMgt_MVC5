namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CopyNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book_Copy", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book_Copy", "Name");
        }
    }
}
