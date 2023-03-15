using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Application.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly IMediator _mediator;

        public TodoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task CreateTodoItemAsync(CreateTodoItemCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task UpdateTodoItemAsync(UpdateTodoItemCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task DeleteTodoItemAsync(DeleteTodoItemCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task<TodoItemDto> GetTodoItemByIdAsync(GetTodoItemByIdQuery query)
        {
            var todoItem = await _mediator.Send(query);
            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted
            };
        }

        public async Task<IEnumerable<TodoItemDto>> GetAllTodoItemsAsync(GetAllTodoItemsQuery query)
        {
            var todoItems = await _mediator.Send(query);
            return todoItems.Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            });
        }
    }
}