using Application.Commands.Todo;
using Application.DTOs.Todo;
using Application.Interfaces;
using Application.Queries.Todo;
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

        public Task CreateTodoItemAsync(CreateTodoItemCommand command) => _mediator.Send(command);

        public Task UpdateTodoItemAsync(UpdateTodoItemCommand command) => _mediator.Send(command);

        public Task DeleteTodoItemAsync(DeleteTodoItemCommand command) => _mediator.Send(command);

        public Task<TodoItemDto> GetTodoItemByIdAsync(GetTodoItemByIdQuery query) => _mediator.Send(query);

        public Task<IEnumerable<TodoItemDto>> GetAllTodoItemsAsync(GetAllTodoItemsQuery query) => _mediator.Send(query);

        public Task<IEnumerable<TodoItemDto>> GetAllTodoItemsWithCategoryAsync(GetAllTodoItemsWithCategoryQuery query) => _mediator.Send(query);
    }
}