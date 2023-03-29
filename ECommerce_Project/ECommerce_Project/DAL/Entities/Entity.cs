using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ECommerce_Project.DAL.Entities
{
    public class Entity
    {
        public virtual Guid Id { get; set; }

        [Display(Name = "Fecha Creación")]
        public virtual DateTime? CreateDate { get; set; }

        [Display(Name = "Fecha Modificación")]
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
