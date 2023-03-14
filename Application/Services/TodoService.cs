using Application.DTOs;
using Application.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Repositories;


namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllTodoItemsAsync()
        {
            var todoItems = await _todoItemRepository.GetAllAsync();
            return todoItems.Select(t => new TodoItemDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            });
        }

        public async Task<TodoItemDto> GetTodoItemByIdAsync(int id)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted
            };
        }

        public async Task<TodoItemDto> CreateTodoItemAsync(TodoItemDto todoItemDto)
        {
            var todoItem = new TodoItem
            {
                Title = todoItemDto.Title,
                IsCompleted = todoItemDto.IsCompleted
            };

            var createdTodoItem = await _todoItemRepository.AddAsync(todoItem);

            return new TodoItemDto
            {
                Id = createdTodoItem.Id,
                Title = createdTodoItem.Title,
                IsCompleted = createdTodoItem.IsCompleted
            };
        }

        public async Task UpdateTodoItemAsync(int id, TodoItemDto todoItemDto)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(id);
            if (todoItem == null)
            {
                throw new KeyNotFoundException($"TodoItem with Id {id} not found.");
            }

            todoItem.Title = todoItemDto.Title;
            todoItem.IsCompleted = todoItemDto.IsCompleted;

            await _todoItemRepository.UpdateAsync(todoItem);
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            await _todoItemRepository.DeleteAsync(id);
        }
    }
}