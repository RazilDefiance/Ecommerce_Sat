using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Project.DAL.Entities
{
    public class Category : Entity
    {
        [Display(Name = "Categoría")]
        [MaxLength(100)]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name  { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }
    }
}
