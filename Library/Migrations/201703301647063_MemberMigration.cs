namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lends",
                c => new
                    {
                        LendID = c.Int(nullable: false, identity: true),
                        Book_CopyID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LendID)
                .ForeignKey("dbo.Book_Copy", t => t.Book_CopyID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.Book_CopyID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            AddColumn("dbo.Book_Copy", "LendingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Book_Copy", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lends", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Lends", "Book_CopyID", "dbo.Book_Copy");
            DropIndex("dbo.Lends", new[] { "MemberID" });
            DropIndex("dbo.Lends", new[] { "Book_CopyID" });
            DropColumn("dbo.Book_Copy", "Description");
            DropColumn("dbo.Book_Copy", "LendingStatus");
            DropTable("dbo.Members");
            DropTable("dbo.Lends");
        }
    }
}
