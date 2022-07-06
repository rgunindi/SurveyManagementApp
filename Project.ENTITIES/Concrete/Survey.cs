using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    internal class Survey
    {
        public int SurveyID { get; set; }
        public List<SurveyQuestion> SurveyQuestion { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public Personel Personel { get; set; }
        public bool SurveyStatus { get; set; }

    }
}
