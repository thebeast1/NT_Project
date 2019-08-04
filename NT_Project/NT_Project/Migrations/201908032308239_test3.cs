namespace NT_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relationships", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Relationships", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relationships", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Relationships", "ApplicationUser_Id");
            AddForeignKey("dbo.Relationships", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
