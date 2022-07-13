using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.ENTITIES.Concrete
{
    public class SurveyQuestion
    {
        [Key]
        public int SurveyQuestionID { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
        public virtual ICollection<Question> SurveyQuestions { get; set; }
        public int? SurveyID { get; set; }
        public virtual Survey Survey { get; set; }
        }
    public enum SurveyQuestionType
    {
        SingleChoiceQuestion,
        MultipleChoiceQuestions,
        OpenEndedQuestion
    }
}