using Application.DTOs.Todo;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Todo
{
    public class GetAllTodoItemsWithCategoryQuery : IRequest<IEnumerable<TodoItemDto>>
    {
    }


}
