namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class question1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "SurveyQuestion_SurveyQuestionID", newName: "SurveyQuestionID");
            RenameIndex(table: "dbo.Questions", name: "IX_SurveyQuestion_SurveyQuestionID", newName: "IX_SurveyQuestionID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Questions", name: "IX_SurveyQuestionID", newName: "IX_SurveyQuestion_SurveyQuestionID");
            RenameColumn(table: "dbo.Questions", name: "SurveyQuestionID", newName: "SurveyQuestion_SurveyQuestionID");
        }
    }
}
