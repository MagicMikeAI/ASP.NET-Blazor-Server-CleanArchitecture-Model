using Application.Queries.Todo;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandlers.Todo
{
    public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItem>
    {
        private readonly ITodoItemRepository _repository;

        public GetTodoItemByIdHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItem> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
