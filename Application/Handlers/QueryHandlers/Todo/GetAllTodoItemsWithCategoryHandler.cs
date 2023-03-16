using Application.Queries.Todo;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandlers.Todo
{
    public class GetAllTodoItemsWithCategoryHandler : IRequestHandler<GetAllTodoItemsWithCategoryQuery, IEnumerable<Domain.Entities.TodoItem>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetAllTodoItemsWithCategoryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<Domain.Entities.TodoItem>> Handle(GetAllTodoItemsWithCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _todoItemRepository.GetAllWithCategoryAsync();
        }
    }
}
