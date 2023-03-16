using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Category
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public CreateCategoryCommand(string name)
        {
            Name = name;
        }
    }
}
