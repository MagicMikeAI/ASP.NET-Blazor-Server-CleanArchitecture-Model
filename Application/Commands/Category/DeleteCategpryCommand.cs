using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
