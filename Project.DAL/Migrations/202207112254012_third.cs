namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Personels", name: "Company_CompanyID", newName: "CompanyID");
            RenameIndex(table: "dbo.Personels", name: "IX_Company_CompanyID", newName: "IX_CompanyID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Personels", name: "IX_CompanyID", newName: "IX_Company_CompanyID");
            RenameColumn(table: "dbo.Personels", name: "CompanyID", newName: "Company_CompanyID");
        }
    }
}
