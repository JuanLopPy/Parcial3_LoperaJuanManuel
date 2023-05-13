using System.ComponentModel.DataAnnotations;

namespace Parcial3.DAL.Entities
{
    public class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
