using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Models
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int ProductionYear { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
    }
}
