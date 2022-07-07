using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        [Required]
        public string AdminName { get; set; }
        [StringLength(20)]
        [Required]
        public string AdminPassword { get; set; }
    }
}
