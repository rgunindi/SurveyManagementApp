namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurveyQuestions", "SurveyQuestionAnswerID", "dbo.SurveyQuestionAnswers");
            DropIndex("dbo.SurveyQuestions", new[] { "SurveyQuestionAnswerID" });
            AlterColumn("dbo.SurveyQuestions", "SurveyQuestionAnswerID", c => c.Int());
            CreateIndex("dbo.SurveyQuestions", "SurveyQuestionAnswerID");
            AddForeignKey("dbo.SurveyQuestions", "SurveyQuestionAnswerID", "dbo.SurveyQuestionAnswers", "SurveyQuestionAnswerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyQuestions", "SurveyQuestionAnswerID", "dbo.SurveyQuestionAnswers");
            DropIndex("dbo.SurveyQuestions", new[] { "SurveyQuestionAnswerID" });
            AlterColumn("dbo.SurveyQuestions", "SurveyQuestionAnswerID", c => c.Int(nullable: false));
            CreateIndex("dbo.SurveyQuestions", "SurveyQuestionAnswerID");
            AddForeignKey("dbo.SurveyQuestions", "SurveyQuestionAnswerID", "dbo.SurveyQuestionAnswers", "SurveyQuestionAnswerID", cascadeDelete: true);
        }
    }
}
