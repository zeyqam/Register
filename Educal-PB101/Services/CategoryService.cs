using Educal_PB101.Data;
using Educal_PB101.Models;
using Educal_PB101.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Educal_PB101.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim()); 
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }
    }
}


            