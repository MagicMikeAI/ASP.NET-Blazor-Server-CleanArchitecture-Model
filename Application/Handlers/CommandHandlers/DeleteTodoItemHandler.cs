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
    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, Unit>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public DeleteTodoItemHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            await _todoItemRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }

}
