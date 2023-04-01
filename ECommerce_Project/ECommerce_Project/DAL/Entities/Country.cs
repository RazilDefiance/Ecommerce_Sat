using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ECommerce_Project.DAL.Entities
{
    public class Country : Entity
    {
        [Display(Name = "País")]
        [MaxLength(50)]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name  { get; set; }

        [Display(Name = "Estados")]
        public ICollection<State> States { get; set; }

        [Display(Name = "# Estados")]
        public int StateTotal => States == null ? 0 : States.Count;

    }
}
