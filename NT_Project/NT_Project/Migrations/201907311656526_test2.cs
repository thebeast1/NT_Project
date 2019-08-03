namespace NT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "user_id_for_comment", c => c.String());
            AlterColumn("dbo.Comments", "post_id", c => c.String());
            AlterColumn("dbo.Posts", "user_id_for_posts", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "user_id_for_posts", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "post_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "user_id_for_comment", c => c.Int(nullable: false));
        }
    }
}
