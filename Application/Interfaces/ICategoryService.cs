using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Category;
using Application.DTOs.Category;
using Application.Queries.Category;
namespace Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDTO);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDTO);
        Task DeleteAsync(Guid id);
    }
}
