using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ECommerce_Project.DAL.Entities
{
    public class Entity
    {
        public virtual Guid Id { get; set; }

        public virtual string? CreateDate { get; set; }

        public virtual string? ModifiedDate { get; set; }
    }
}
