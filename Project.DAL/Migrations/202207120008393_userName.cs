namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personels", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personels", "UserName");
        }
    }
}
