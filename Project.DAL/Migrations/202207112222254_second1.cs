namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Companies", new[] { "CompanyID" });
            RenameColumn(table: "dbo.Personels", name: "CompanyID", newName: "Company_CompanyID");
            DropPrimaryKey("dbo.Companies");
            AlterColumn("dbo.Companies", "CompanyID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Companies", "CompanyID");
            CreateIndex("dbo.Personels", "Company_CompanyID");
            AddForeignKey("dbo.Personels", "Company_CompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies", "CompanyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Personels", "Company_CompanyID", "dbo.Companies");
            DropIndex("dbo.Personels", new[] { "Company_CompanyID" });
            DropPrimaryKey("dbo.Companies");
            AlterColumn("dbo.Companies", "CompanyID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Companies", "CompanyID");
            RenameColumn(table: "dbo.Personels", name: "Company_CompanyID", newName: "CompanyID");
            CreateIndex("dbo.Companies", "CompanyID");
            AddForeignKey("dbo.Surveys", "CompanyID", "dbo.Companies", "CompanyID");
        }
    }
}
