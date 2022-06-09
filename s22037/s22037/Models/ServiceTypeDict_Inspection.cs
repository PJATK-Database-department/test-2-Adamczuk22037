using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s22037.Models
{
    public class ServiceTypeDict_Inspection
    {
        [Key]
        public int IdServiceType { get; set; }

        [ForeignKey("IdServiceType")]
        public ServiceTypeDict ServiceType { get; set; }

        [Key]
        public int IdInspection { get; set; }

        [ForeignKey("IdInspection")]
        public Inspection Inspection { get; set; }

        [MaxLength(300)]
        public String Comments { get; set; }
    }
}
