using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Todo
{
    public class UpdateTodoItemCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public Guid CategoryId { get; }


        public UpdateTodoItemCommand(Guid id, string title, bool isCompleted, Guid categoryId) // Add categoryId to the constructor
        {
            Id = id;
            Title = title;
            IsCompleted = isCompleted;
            CategoryId = categoryId; 
        }
    }

}
