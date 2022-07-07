using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [StringLength(20)]
        [Required]
        public string CompanyName { get; set; }
        public ICollection<Personel> CompanyPersonels { get; set; }

    }
}
