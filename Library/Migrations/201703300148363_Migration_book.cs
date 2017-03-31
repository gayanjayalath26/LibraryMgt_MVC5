namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_book : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book_Copy",
                c => new
                    {
                        Book_CopyID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Book_CopyID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookISBN = c.String(),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book_Copy", "BookID", "dbo.Books");
            DropIndex("dbo.Book_Copy", new[] { "BookID" });
            DropTable("dbo.Books");
            DropTable("dbo.Book_Copy");
        }
    }
}
