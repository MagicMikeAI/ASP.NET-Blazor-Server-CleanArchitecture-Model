using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return (IEnumerable<TodoItem>)await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(Guid id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem> AddAsync(TodoItem entity)
        {
            _context.TodoItems.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TodoItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.TodoItems.FindAsync(id);
            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<TodoItem>> GetAllTodoItemsWithCategoryAsync()
        {
            return await _context.TodoItems.Include(t => t.Category).ToListAsync();
        }
    }
}