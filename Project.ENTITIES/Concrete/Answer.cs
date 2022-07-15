using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Answer
    {
        [Key]
        public int AnswerID{ get; set; }
        public int PersonelID { get; set; }
        public int SurveyID { get; set; }
        public string PerAnswer { get; set; }
        public int SurveyQuestionID { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
