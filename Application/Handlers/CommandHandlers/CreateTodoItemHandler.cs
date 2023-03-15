using Application.Commands;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, Unit>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public CreateTodoItemHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<Unit> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            await _todoItemRepository.AddAsync(request.TodoItem);
            return Unit.Value;
        }
    }

}
