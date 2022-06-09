using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Models
{
    public class Inspection
    {
        [Key]
        public int IdInspection { get; set; }

        [Required]
        public int IdCar { get; set; }

        [ForeignKey("IdCar")]
        public Car Car { get; set; }

        [Required]
        public int IdMechanic { get; set; }

        [ForeignKey("IdMechanic")]
        public Mechanic Mechanic { get; set; }

        [Required]
        public DateTime InspectionDate { get; set; }

        [MaxLength(300)]
        public String Comment { get; set; }

        public virtual ICollection<ServiceTypeDict_Inspection> ServiceTypeDict_Inspections { get; set; }
    }
}
