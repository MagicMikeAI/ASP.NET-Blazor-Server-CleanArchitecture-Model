using Application.Commands.Todo;
using Application.DTOs.Todo;
using Application.Queries.Todo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITodoService
    {
        Task CreateTodoItemAsync(CreateTodoItemCommand command);
        Task UpdateTodoItemAsync(UpdateTodoItemCommand command);
        Task DeleteTodoItemAsync(DeleteTodoItemCommand command);
        Task<TodoItemDto> GetTodoItemByIdAsync(GetTodoItemByIdQuery query);
        Task<IEnumerable<TodoItemDto>> GetAllTodoItemsAsync(GetAllTodoItemsQuery query);
        Task<IEnumerable<TodoItemDto>> GetAllTodoItemsWithCategoryQuery(GetAllTodoItemsWithCategoryQuery query);
    }

}
