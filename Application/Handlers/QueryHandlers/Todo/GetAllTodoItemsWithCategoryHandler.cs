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
    public class GetAllTodoItemsWithCategoryHandler : IRequestHandler<GetAllTodoItemsWithCategoryQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetAllTodoItemsWithCategoryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetAllTodoItemsWithCategoryQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _todoItemRepository.GetAllTodoItemsWithCategoryAsync();

            return todoItems.Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CategoryId = item.Category?.Id ?? Guid.Empty,
                CategoryName = item.Category?.Name
            });
        }
    }

}
