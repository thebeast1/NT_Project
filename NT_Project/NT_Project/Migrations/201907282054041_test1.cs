namespace NT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment_message = c.String(),
                        comment_date = c.DateTime(),
                        post_id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.post_id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        post_message = c.String(),
                        post_date = c.DateTime(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comment_id = c.Int(),
                        post_id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Comments", t => t.comment_id)
                .ForeignKey("dbo.Posts", t => t.post_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.comment_id)
                .Index(t => t.post_id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        friend_id = c.Int(nullable: false),
                        date_of_friendship = c.DateTime(),
                        status = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reacts", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reacts", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Reacts", "comment_id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "user_Id" });
            DropIndex("dbo.Reacts", new[] { "user_Id" });
            DropIndex("dbo.Reacts", new[] { "post_id" });
            DropIndex("dbo.Reacts", new[] { "comment_id" });
            DropIndex("dbo.Posts", new[] { "user_Id" });
            DropIndex("dbo.Comments", new[] { "user_Id" });
            DropIndex("dbo.Comments", new[] { "post_id" });
            DropTable("dbo.Relationships");
            DropTable("dbo.Reacts");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
