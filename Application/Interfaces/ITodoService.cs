using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetAllTodoItemsAsync();
        Task<TodoItemDto> GetTodoItemByIdAsync(int id);
        Task<TodoItemDto> CreateTodoItemAsync(TodoItemDto todoItemDto);
        Task UpdateTodoItemAsync(int id, TodoItemDto todoItemDto);
        Task DeleteTodoItemAsync(int id);
    }
}
