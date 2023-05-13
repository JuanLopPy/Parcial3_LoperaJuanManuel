using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Parcial3.DAL.Entities
{
    public class VehicleDetails:Vehicles
    {
        [ForeignKey("Servicio")]
        public int VehiculeId { get; set; }


        [Display(Name = ("Fecha entrada del vehiculo"))]
        public virtual DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = ("Fecha entrega del vehiculo"))]
        public virtual DateTime DeliveryDate { get; set; } = DateTime.Now;

    }
}
