using Application.Commands.Todo;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers.Todo
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, Unit>
    {
        private readonly ITodoItemRepository _todoItemRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateTodoItemHandler(ITodoItemRepository todoItemRepository, ICategoryRepository categoryRepository)
        {
            _todoItemRepository = todoItemRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.TodoItemCreateDto.CategoryId);

            if (category == null)
            {
                throw new ArgumentException("Invalid CategoryId");
            }

            var todoItem = new TodoItem
            {
                Title = request.TodoItemCreateDto.Title,
                IsCompleted = request.TodoItemCreateDto.IsCompleted ?? false, //IsCompleted is set to false if the value is null.
                Category = category
            };

            await _todoItemRepository.AddAsync(todoItem);

            return Unit.Value;
        }
    }


}
