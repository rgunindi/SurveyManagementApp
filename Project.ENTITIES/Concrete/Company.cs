using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    internal class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public List<Personel> CompanyPersonels { get; set; }

    }
}
