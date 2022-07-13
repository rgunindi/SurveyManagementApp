using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Project.ENTITIES.Concrete
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        [StringLength(20)]
        [Required]
        public string CompanyName { get; set; }
        public virtual ICollection<Personel> CompanyPersonels { get; set; }
    }
}
