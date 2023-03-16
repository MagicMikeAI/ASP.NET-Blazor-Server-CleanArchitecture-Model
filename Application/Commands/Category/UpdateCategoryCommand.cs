using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateCategoryCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
