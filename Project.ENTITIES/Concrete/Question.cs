using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        [Required]
        public string Q { get; set; }
        public int? SurveyQuestionID { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
        public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswer { get; set; }
    }
}
