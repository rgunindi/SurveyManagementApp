using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.ENTITIES.Concrete
{
    public class SurveyQuestionAnswer
    {
        [Key]
        public int SurveyQuestionAnswerID { get; set; }
        public string Answer { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}