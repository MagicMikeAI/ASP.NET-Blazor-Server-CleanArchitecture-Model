using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Todo
{
    public class CreateTodoItemDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public Guid CategoryId { get; set; }

    }
}
