using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateTodoItemCommand : IRequest<Unit>
    {
        public TodoItem TodoItem { get; set; }

        public CreateTodoItemCommand(TodoItem todoItem)
        {
            TodoItem = todoItem;
        }
    }

}
