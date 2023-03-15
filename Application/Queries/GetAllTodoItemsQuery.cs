using Application.Handlers.QueryHandlers;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {
    }

}
