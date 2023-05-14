using System.ComponentModel.DataAnnotations;

namespace Parcial3.DAL.Entities
{
    public class Service:Entity
    {
        public Service()
        {
            Vehicles = new HashSet<Vehicle>();
        }
        [Display(Name = "Servicio")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Name { get; set; }
        [Display(Name = "precio")]
        
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Price { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }

    }
}
