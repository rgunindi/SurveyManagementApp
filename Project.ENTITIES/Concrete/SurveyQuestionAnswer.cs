using System.Collections.Generic;

namespace Project.ENTITIES.Concrete
{
    public class SurveyQuestionAnswer
    {
        public int SurveyQuestionAnswerID { get; set; }
        public int SurveyQuestionID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public List<string> Answer { get; set; }
        public int SurveyQuestionTypeID { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
    }
}