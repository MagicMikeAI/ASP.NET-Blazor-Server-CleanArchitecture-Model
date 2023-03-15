using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> AddAsync(TodoItem entity);
        Task UpdateAsync(TodoItem entity);
        Task DeleteAsync(Guid id);
        Task<TodoItem> GetByIdAsync(Guid id);
    }
}