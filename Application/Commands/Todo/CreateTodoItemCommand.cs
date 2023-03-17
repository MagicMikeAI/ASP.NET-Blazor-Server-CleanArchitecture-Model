using Application.DTOs.Todo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Todo
{
    public class CreateTodoItemCommand : IRequest<Unit>
    {
        public CreateTodoItemDto TodoItemCreateDto { get; set; }

        public CreateTodoItemCommand(CreateTodoItemDto todoItemCreateDto)
        {
            TodoItemCreateDto = todoItemCreateDto;
        }
    }




}
