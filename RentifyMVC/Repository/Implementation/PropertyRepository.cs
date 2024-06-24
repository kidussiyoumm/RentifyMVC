using Microsoft.EntityFrameworkCore;
using Rentify.Models.Domains;
using RentifyMVC.Data;
using RentifyMVC.Repository.Interfaces;

namespace RentifyMVC.Repository.Implementation
{
    public class PropertyRepository : IProperty
    {
        private readonly RentifyDbContext _dbContext;
        public PropertyRepository(RentifyDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<List<Property>> ListPropertyAsync()
        {
            return await _dbContext.Properties.ToListAsync();
        }

        public async Task<Property> CreatePropertyAsync(Property property)
        {
            try
            {
                if (property == null)
                {
                    throw new Exception("Please try again, Invaild Input");
                }

                await _dbContext.Properties.AddAsync(property);
                await _dbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return property;
        }

    }
}
