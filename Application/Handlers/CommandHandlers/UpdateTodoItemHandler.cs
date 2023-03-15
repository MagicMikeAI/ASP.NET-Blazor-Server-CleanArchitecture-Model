using Application.Commands;
using Application.Exceptions;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers
{
    public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, Unit>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public UpdateTodoItemHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _todoItemRepository.GetByIdAsync(request.Id);
            if (todoItem == null)
            {
                throw new NotFoundException(nameof(TodoItem), request.Id);
            }

            todoItem.Title = request.Title;
            todoItem.IsCompleted = request.IsCompleted;

            await _todoItemRepository.UpdateAsync(todoItem);

            return Unit.Value;
        }
    }

}
