using ECommerce_Project.DAL.Entities;

namespace ECommerce_Project.Models
{
    public class StateViewModel :State
    {
        public Guid CountryId { get; set; }
    }
}
