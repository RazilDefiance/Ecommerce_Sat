using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Project.DAL.Entities
{
    public class Country : Entity
    {
        [Display(Name = "País")]
        [MaxLength(50)]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name  { get; set; }
    }
}
