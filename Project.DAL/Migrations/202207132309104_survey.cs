namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class survey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Surveys", "PersonelID", "dbo.Personels");
            DropIndex("dbo.Surveys", new[] { "PersonelID" });
            AddColumn("dbo.Personels", "SurveyID", c => c.Int());
            AddColumn("dbo.Personels", "IsAnonymous", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Personels", "SurveyID");
            AddForeignKey("dbo.Personels", "SurveyID", "dbo.Surveys", "SurveyID");
            DropColumn("dbo.Surveys", "PersonelID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "PersonelID", c => c.Int());
            DropForeignKey("dbo.Personels", "SurveyID", "dbo.Surveys");
            DropIndex("dbo.Personels", new[] { "SurveyID" });
            DropColumn("dbo.Personels", "IsAnonymous");
            DropColumn("dbo.Personels", "SurveyID");
            CreateIndex("dbo.Surveys", "PersonelID");
            AddForeignKey("dbo.Surveys", "PersonelID", "dbo.Personels", "PersonelID");
        }
    }
}
