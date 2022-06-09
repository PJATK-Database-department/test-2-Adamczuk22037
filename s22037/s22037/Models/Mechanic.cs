using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Models
{
    public class Mechanic
    {
        [Key]
        public int IdMechanic { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
