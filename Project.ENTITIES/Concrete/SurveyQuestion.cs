using System.ComponentModel.DataAnnotations;

namespace Project.ENTITIES.Concrete
{
    public class SurveyQuestion
    {
        [Key]
        public int SurveyQuestionID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
        public int? SurveyQuestionAnswerID { get; set; }
        public virtual SurveyQuestionAnswer SurveyQuestionAnswer { get; set; }
        public virtual Survey Survey { get; set; }
    }
    public enum SurveyQuestionType
    {
        Radio,
        Checkbox,
        Text
    }
}