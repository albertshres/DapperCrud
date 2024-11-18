//this is third step
using DapperCrudYtb.Models;

namespace DapperCrudYtb.Services
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetAllAsync();
        Task<Bike> GetByIdAsync(int id);

        Task<int> CreateAsync(Bike bike);

        Task<int> UpdateAsync(Bike bike);

        Task<int> DeleteAsync(int id);   

    }
}
