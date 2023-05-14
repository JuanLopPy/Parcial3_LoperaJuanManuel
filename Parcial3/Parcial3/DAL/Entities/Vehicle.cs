﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Parcial3.DAL.Entities
{
    public class Vehicle:Entity
    {

        [ForeignKey("Servicio")] 
        public Guid ServiceId { get; set; }
       public virtual Service Services { get; set; }
    [Display(Name = "Propietario")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String? Owner { get; set; }

        [Display(Name = "Número de placa")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]

        public String? NumberPlate { get; set; }



    }
}
