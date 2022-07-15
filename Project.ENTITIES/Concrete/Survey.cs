using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Survey
    {
        [Key]
        public int SurveyID { get; set; }
        public string SurveyTitle { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Personel> SurveyPersonels { get; set; }
        public bool SurveyStatus { get; set; }

    }
}
