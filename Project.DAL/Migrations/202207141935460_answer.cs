namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        PersonelID = c.Int(nullable: false),
                        SurveyID = c.Int(nullable: false),
                        PerAnswer = c.String(),
                        SurveyQuestionID = c.Int(nullable: false),
                        IsAnonymous = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Answers");
        }
    }
}
