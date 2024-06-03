using Educal_PB101.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Educal_PB101.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task CreateAsync(Category category);
        Task< bool> ExistAsync(string name);
        Task<SelectList> GetAllSelectedAsync();
    }
}
