namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personels", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Personels", new[] { "CompanyID" });
            AlterColumn("dbo.Personels", "CompanyID", c => c.Int());
            CreateIndex("dbo.Personels", "CompanyID");
            AddForeignKey("dbo.Personels", "CompanyID", "dbo.Companies", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personels", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Personels", new[] { "CompanyID" });
            AlterColumn("dbo.Personels", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.Personels", "CompanyID");
            AddForeignKey("dbo.Personels", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
