using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.ENTITIES.Concrete
{
    public class SurveyQuestionAnswer
    {
        [Key]
        public int SurveyQuestionAnswerID { get; set; }
        public int SurveyQuestionID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
    }
}