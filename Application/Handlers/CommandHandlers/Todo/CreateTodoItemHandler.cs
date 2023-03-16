using Application.Commands.Todo;
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
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                throw new ArgumentException("Invalid CategoryId");
            }

            request.TodoItem.Category = category;
            await _todoItemRepository.AddAsync(request.TodoItem);
            return Unit.Value;
        }
    }

}
