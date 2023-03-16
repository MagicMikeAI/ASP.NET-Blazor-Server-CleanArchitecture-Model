using Application.Queries.Todo;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandlers.Todo
{
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly ITodoItemRepository _repository;

        public GetAllTodoItemsHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
