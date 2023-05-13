using System.ComponentModel.DataAnnotations;

namespace Parcial3.DAL.Entities
{
    public class Services:Entity
    {
        [Display(Name = "Servicio")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Name { get; set; }
        [Display(Name = "precio")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Price { get; set; }


    }
}
