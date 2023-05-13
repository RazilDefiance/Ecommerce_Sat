using ECommerce_Project.DAL.Entities;

namespace ECommerce_Project.Models
{
    public class CityViewModel : City
    {
        public Guid StateId { get; set; }
    }
}
