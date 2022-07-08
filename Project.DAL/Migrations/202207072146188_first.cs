namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Surveys", new[] { "CompanyID" });
            AlterColumn("dbo.Surveys", "CompanyID", c => c.Int());
            CreateIndex("dbo.Surveys", "CompanyID");
            AddForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Surveys", new[] { "CompanyID" });
            AlterColumn("dbo.Surveys", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Surveys", "CompanyID");
            AddForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
