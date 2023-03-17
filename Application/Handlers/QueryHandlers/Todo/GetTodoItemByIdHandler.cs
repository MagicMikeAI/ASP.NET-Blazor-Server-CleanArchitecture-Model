using Application.DTOs.Todo;
using Application.Queries.Todo;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandlers.Todo
{
    public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto>
    {
        private readonly ITodoItemRepository _repository;

        public GetTodoItemByIdHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItemDto> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await _repository.GetByIdAsync(request.Id);
            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted
            };
        }
    }
}
