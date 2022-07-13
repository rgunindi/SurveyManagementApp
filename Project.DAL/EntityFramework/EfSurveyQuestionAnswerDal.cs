using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Abstract;
using Project.DAL.Concrete.Repositories;
using Project.ENTITIES.Concrete;

namespace Project.DAL.EntityFramework
{
    public class EfSurveyQuestionAnswerDal : GenericRepository<SurveyQuestionAnswer>, ISurveyQuestionAnswerDal
    {
    }
}
