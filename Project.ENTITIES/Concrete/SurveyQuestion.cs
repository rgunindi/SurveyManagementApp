namespace Project.ENTITIES.Concrete
{
    internal class SurveyQuestion
    {
        public int SurveyQuestionID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public int SurveyQuestionTypeID { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
        public int SurveyQuestionAnswerID { get; set; }
        public SurveyQuestionAnswer SurveyQuestionAnswer { get; set; }
    }
}