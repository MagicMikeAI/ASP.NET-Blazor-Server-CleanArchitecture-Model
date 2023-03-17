using Application.DTOs.Todo;
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
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetAllTodoItemsHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _todoItemRepository.GetAllAsync();

            return todoItems.Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            });
        }
    }

}
