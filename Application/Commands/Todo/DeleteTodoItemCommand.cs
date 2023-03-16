using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Todo
{
    public class DeleteTodoItemCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteTodoItemCommand(Guid id)
        {
            Id = id;
        }
    }
}
