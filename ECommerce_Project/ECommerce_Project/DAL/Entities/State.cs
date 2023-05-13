using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_Project.DAL.Entities
{
    public class State : Entity
    {
        [Display(Name = "Eatado")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public Country Country { get; set; }

        [Display(Name = "Ciudades")] //Nombre que quiero mostrar en la web
        public ICollection<City> Cities { get; set; }

        //Propiedad de lectura...
        [Display(Name = "Número Ciudades")] //Nombre que quiero mostrar en la web
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;

    }
}
