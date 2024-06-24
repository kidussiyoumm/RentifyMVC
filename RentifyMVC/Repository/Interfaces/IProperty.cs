using Rentify.Models.Domains;

namespace RentifyMVC.Repository.Interfaces
{
    public interface IProperty
    {
        Task<List<Property>> ListPropertyAsync();

        Task<Property> CreatePropertyAsync(Property property);  
    }
}
